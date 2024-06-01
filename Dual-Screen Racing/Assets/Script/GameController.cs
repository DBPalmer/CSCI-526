using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform zoom1;

    public Transform zoom2;

    public TextMeshProUGUI scoreText;

    public Transform carLeft;

    public Transform carRight;

    private float currentScore = 0f;

    private float scoreMultiplier = 1.0f;

    private readonly float baseScore = 1.0f;

    void Start()
    {
        // Default start state
        CarRightStop();

        if (scoreText != null)
        {
            InvokeRepeating("CalculateScore", 1, 1);
        }
    }

    void Update()
    {
    }

    public void SwitchScreen(string carName)
    {
        if (carName == "CarLeft")
        {
            CarLeftStop();
        }
        else
        {
            CarRightStop();
        }
    }

    public void CarLeftStop()
    {
        // stop zoom1 object movement
        zoom1.GetComponent<SpawnObjController>().isStopSpawn = true;
        foreach (Transform t in zoom1)
        {
            t.GetComponent<ObjMove>().speed = 0;
        }

        // start zoom2 object movement
        zoom2.GetComponent<SpawnObjController>().isStopSpawn = false;
        foreach (Transform t in zoom2)
        {
            t.GetComponent<ObjMove>().speed = t.GetComponent<ObjMove>().moveSpeed;
        }

        // stop CarLeft movement
        carLeft.GetComponent<CarMove>().canMove = false;

        // start CarRight movement
        carRight.GetComponent<CarMove>().canMove = true;
    }

    public void CarRightStop()
    {
        // stop zoom2 object movement
        zoom2.GetComponent<SpawnObjController>().isStopSpawn = true;
        foreach (Transform t in zoom2)
        {
            t.GetComponent<ObjMove>().speed = 0;
        }

        // start zoom1 object movement
        zoom1.GetComponent<SpawnObjController>().isStopSpawn = false;
        foreach (Transform t in zoom1)
        {
            t.GetComponent<ObjMove>().speed = t.GetComponent<ObjMove>().moveSpeed;
        }

        // stop CarRight movement
        carRight.GetComponent<CarMove>().canMove = false;

        // start CarLeft movement
        carLeft.GetComponent<CarMove>().canMove = true;
    }

    void CalculateScore()
    {
        currentScore += baseScore * scoreMultiplier;
        scoreText.text = "Score: " + currentScore.ToString("F0");
    }

    public void ActivateBonus()
    {
        StartCoroutine(Prop2BonusScore());
    }

    IEnumerator Prop2BonusScore()
    {
        scoreMultiplier = 2.0f;
        yield return new WaitForSeconds(5.0f);
        scoreMultiplier = 1.0f;
    }
}
