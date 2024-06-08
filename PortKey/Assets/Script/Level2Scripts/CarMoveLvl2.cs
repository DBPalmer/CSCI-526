using System.Collections;
using UnityEngine;
using TMPro;

public class CarMoveLvl2 : MonoBehaviour
{
    public float carSpeed = 300f;

    public bool actionAD = false;

    public float boundaryLeft = -850f;

    public float boundaryRight = -50f;

    public bool canMove = true;

    public TextMeshProUGUI deathText;

    void Start()
    {
        print(transform.GetComponent<RectTransform>().anchoredPosition.x);
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }

        float posX = transform.GetComponent<RectTransform>().anchoredPosition.x;

        if (actionAD)
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
        else
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
        GameContrLvl2 gameController = FindObjectOfType<GameContrLvl2>();

        if (other.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            deathText.text = "YOU DIED";
            deathText.color = Color.red;
        }

        if (other.gameObject.name.Contains("Prop1"))
        {
            Destroy(other.gameObject);
            gameController.SwitchScreen(transform.name);
            gameController.OneTimeBonus();
            canMove = false;
        }

        if (other.gameObject.name.Contains("Prop2"))
        {
            Destroy(other.gameObject);
            actionAD = !actionAD;
            gameController.ActivateBonus();
        }
    }
}
