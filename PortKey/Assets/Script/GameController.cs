using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform zoom1;

    public Transform zoom2;

    public TextMeshProUGUI leftScore;

    public TextMeshProUGUI rightScore;

    public TextMeshProUGUI leftMsg;

    public TextMeshProUGUI rightMsg;

    public TextMeshProUGUI broadcastMsg;

    public Transform carLeft;

    public Transform carRight;

    public Sprite spriteA;

    public Sprite spriteD;

    public Image imageA;

    public Image imageD;

    public Sprite spriteLeft;

    public Sprite spriteRight;

    public Image imageLeft;

    public Image imageRight;

    private float currentLeftScore = 0f;

    private float currentRightScore = 0f;

    private float scoreMultiplier = 1.0f;

    private readonly float baseScore = 1.0f;

    // game duration, unit is second
    private float gameDuration = 5f;

    void Start()
    {
        Time.timeScale = 1;

        if (leftScore != null)
        {
            InvokeRepeating("CalculateScoreLeft", 1, 1);
        }

        if (rightScore != null)
        {
            InvokeRepeating("CalculateScoreRight", 1, 1);
        }

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
        broadcastMsg.text = "LEVEL COMPLETED";
        broadcastMsg.color = Color.green;
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

    public void EnemyControlReverse(string carName)
    {
        if (carName == "CarLeft")
        {
            carRight.GetComponent<CarMove>().carSpeed *= -1;
            carRight.GetComponent<CarMove>().reversed = !carRight.GetComponent<CarMove>().reversed;
            if (carRight.GetComponent<CarMove>().reversed)
            {
                rightMsg.text = "REVERSE";
            }
            imageA.sprite = spriteD;
            imageD.sprite = spriteA;
        }
        else
        {
            carLeft.GetComponent<CarMove>().carSpeed *= -1;
            if (carLeft.GetComponent<CarMove>().reversed)
            {
                leftMsg.text = "REVERSE";
            }
            imageLeft.sprite = spriteRight;
            imageRight.sprite = spriteLeft;
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

    public void StopScoreCalculation(string carName)
    {
        if (carName == "CarLeft")
        {
            CancelInvoke("CalculateScoreLeft");
        }
        else if (carName == "CarRight")
        {
            CancelInvoke("CalculateScoreRight");
        }
    }

    void CalculateScoreLeft()
    {
        currentLeftScore += baseScore * scoreMultiplier;
        leftScore.text = "Score: " + currentLeftScore.ToString("F0");
    }

    void CalculateScoreRight()
    {
        currentRightScore += baseScore * scoreMultiplier;
        rightScore.text = "Score: " + currentRightScore.ToString("F0");
    }

    public void OneTimeBonus(string carName)
    {
        if (carName == "CarLeft")
        {
            currentLeftScore += 5;
            leftScore.text = "Score: " + currentLeftScore.ToString("F0");
        }
        else
        {
            currentRightScore += 5;
            rightScore.text = "Score: " + currentRightScore.ToString("F0");
        }
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
