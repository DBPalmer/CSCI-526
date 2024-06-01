using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class CarMove : MonoBehaviour
{
    public float speed = 10f;

    public bool actionAD = false;

    public TextMeshProUGUI scoreText;

    float currentScore = 0f;

    float bonus = 1.0f;

    public float boundLeft = -2.5f;

    public float boundRight = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText != null)
        {
            InvokeRepeating("CalculateScore", 1, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {

        // print the position of the car
        print(transform.GetComponent<RectTransform>().anchoredPosition.x);


        // A&D
        if (actionAD)
        {
            if (Input.GetKey(KeyCode.A) && transform.GetComponent<RectTransform>().anchoredPosition.x > boundLeft)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && transform.GetComponent<RectTransform>().anchoredPosition.x < boundRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        // Left&Right
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.GetComponent<RectTransform>().anchoredPosition.x > boundLeft)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow) && transform.GetComponent<RectTransform>().anchoredPosition.x < boundRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

        }


    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            //Destroy(gameObject);
        }

        if (other.gameObject.name.Contains("prop1"))
        {
            Destroy(other.gameObject);
            if (transform.name == "Car1")
            {
                FindObjectOfType<CarController>().Zoom1Stop();
            }
            else
            {
                FindObjectOfType<CarController>().Zoom2Stop();
            }
        }

        if (other.gameObject.name.Contains("prop2"))
        {
            Destroy(other.gameObject);
            actionAD = !actionAD;
            StartCoroutine(BonusScore());
        }
    }


    void CalculateScore()
    {
        currentScore += bonus;
        scoreText.text = currentScore.ToString();
    }


    IEnumerator BonusScore()
    {
        bonus = 2.0f;
        yield return new WaitForSeconds(5.0f);
        bonus = 1.0f;
    }
}
