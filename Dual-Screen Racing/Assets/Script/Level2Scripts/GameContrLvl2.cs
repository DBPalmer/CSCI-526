using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameContrLvl2 : MonoBehaviour
{
    public Transform zoom1;

    public Transform zoom2;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI successText;

    public Transform carLeft;

    public Transform carRight;

    private float currentScore = 0f;

    private float scoreMultiplier = 1.0f;

    private readonly float baseScore = 1.0f;

    // game duration, unit is second
    private float gameDuration = 30f;

    void Start()
    {
        Time.timeScale = 1;

        // Default start state
        CarRightStop();

        if (scoreText != null)
        {
            InvokeRepeating("CalculateScore", 1, 1);
        }

        // Start countdown timer
        StartCoroutine(CountdownTimer());
    }

    void Update()
    {
    }

    IEnumerator CountdownTimer()
    {
        while (gameDuration > 0)
        {
            yield return new WaitForSeconds(1f);
            // Decrease game duration by 1 second
            gameDuration -= 1f;
        }

        // Pause the game when the game duration is over
        PauseGame();
        successText.text = "LEVEL COMPLETED";
        successText.color = Color.green;
    }

    void PauseGame()
    {
        // Stop the game
        Time.timeScale = 0;
        Debug.Log("Game Paused! Time's up.");
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
        zoom1.GetComponent<SpawnObjLvl2>().isStopSpawn = true;
        foreach (Transform t in zoom1)
        {
            t.GetComponent<ObjMove>().speed = 0;
        }

        // start zoom2 object movement
        zoom2.GetComponent<SpawnObjLvl2>().isStopSpawn = false;
        foreach (Transform t in zoom2)
        {
            t.GetComponent<ObjMove>().speed = t.GetComponent<ObjMove>().moveSpeed;
        }

        // stop CarLeft movement
        carLeft.GetComponent<CarMoveLvl2>().canMove = false;

        // start CarRight movement
        carRight.GetComponent<CarMoveLvl2>().canMove = true;
    }

    public void CarRightStop()
    {
        // stop zoom2 object movement
        zoom2.GetComponent<SpawnObjLvl2>().isStopSpawn = true;
        foreach (Transform t in zoom2)
        {
            t.GetComponent<ObjMove>().speed = 0;
        }

        // start zoom1 object movement
        zoom1.GetComponent<SpawnObjLvl2>().isStopSpawn = false;
        foreach (Transform t in zoom1)
        {
            t.GetComponent<ObjMove>().speed = t.GetComponent<ObjMove>().moveSpeed;
        }

        // stop CarRight movement
        carRight.GetComponent<CarMoveLvl2>().canMove = false;

        // start CarLeft movement
        carLeft.GetComponent<CarMoveLvl2>().canMove = true;
    }

    void CalculateScore()
    {
        currentScore += baseScore * scoreMultiplier;
        scoreText.text = "Score: " + currentScore.ToString("F0");
    }

    public void OneTimeBonus()
    {
        currentScore += 5;
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
