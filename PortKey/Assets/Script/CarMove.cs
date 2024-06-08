using System.Collections;
using UnityEngine;
using TMPro;

public class CarMove : MonoBehaviour
{
    public float carSpeed = 300f;

    public bool actionAD = false;

    public float boundaryLeft = -850f;

    public float boundaryRight = -50f;

    public bool canMove = true;

    public TextMeshProUGUI deathText;

    public bool reversed = false;


    void Start()
    {
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }

        float posX = transform.GetComponent<RectTransform>().anchoredPosition.x;

        if (transform.name == "CarLeft")
        {
            if (Input.GetKey(KeyCode.A) && posX > boundaryLeft)
            {
                transform.Translate(Vector3.left * carSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && posX < boundaryRight)
            {
                transform.Translate(Vector3.right * carSpeed * Time.deltaTime);
            }
        }

        if (transform.name == "CarRight")
        {
            if (Input.GetKey(KeyCode.LeftArrow) && posX > boundaryLeft)
            {
                transform.Translate(Vector3.left * carSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow) && posX < boundaryRight)
            {
                transform.Translate(Vector3.right * carSpeed * Time.deltaTime);
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameController gameController = FindObjectOfType<GameController>();

        if (other.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            deathText.text = "YOU DIED";
            deathText.color = Color.red;
            gameController.StopScoreCalculation(transform.name);
        }

        if (other.gameObject.name.Contains("EnemyControlReverse"))
        {
            Destroy(other.gameObject);
            gameController.EnemyControlReverse(transform.name);
        }

        if (other.gameObject.name.Contains("ScoreUp"))
        {
            Destroy(other.gameObject);
            gameController.OneTimeBonus(transform.name);
        }
    }
}
