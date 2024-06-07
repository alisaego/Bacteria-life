using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    float move_x = 0, move_y = 0;
    public float food;
    public int health, dna, score;
    GameObject Player_Overlay;
   
    [SerializeField] float speed;
    void Start()
    {
        food = 4; health = 10;
        score = 0;
        Player_Overlay = GameObject.FindGameObjectWithTag("Overlay0");
        Player_Overlay.transform.GetChild(2).GetComponent<RectTransform>().localScale = new Vector3((score + 1) / 1000.0f, 1, 1);
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewCamera>().pause == false)
        {


            if (Input.GetKey(KeyCode.W))
            {
                move_y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                move_y = -1;
            }
            else
            {
                move_y = 0;
            }

            if (Input.GetKey(KeyCode.D))
            {
                move_x = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                move_x = -1;
            }
            else
            {
                move_x = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewCamera>().pause == false)
        {
            if (food > 0)
                food -= 0.01f;
            else
                health -= 1;


            transform.position += new Vector3(move_x, move_y, 0) * (speed / 10);

            if (health < 0)
                Destroy(gameObject);
            if (food > 50)
                food = 50;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grass")
        {
            food += 10f;
            dna += 1;
            score += 1;
            Player_Overlay.transform.GetChild(2).GetComponent<RectTransform>().localScale = new Vector3((score + 1) / 1000.0f, 1, 1);
            Player_Overlay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "ÄÍÊ: " + dna;
            Destroy(collision.gameObject);
        }
    }
}
