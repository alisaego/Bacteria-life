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
    public float speed;
    public float endurance;
    [SerializeField] GameObject lose_menu;
    void Start()
    {
        food = 4; health = 10;
        score = 0;
        Player_Overlay = GameObject.FindGameObjectWithTag("Overlay0");
        Player_Overlay.transform.GetChild(2).GetComponent<RectTransform>().localScale = new Vector3((score + 1) / 100.0f, 1, 1);
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
                food -= (0.01f / endurance);
            else
                health -= 1;


            transform.position += new Vector3(move_x, move_y, 0) * (speed / 10);

            
            if (food > 50)
                food = 50;


        }
        if (health < 0)
        {
            lose_menu.GetComponent<lose_game>().Lose_game();
            gameObject.GetComponent<SpriteRenderer>().color = new Color(181, 253, 177, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grass")
        {
            food += 10f;
            dna += 1;
            score += 1;
            Player_Overlay.transform.GetChild(2).GetComponent<RectTransform>().localScale = new Vector3((score + 1) / 100.0f, 1, 1);
            Player_Overlay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DNA: " + dna;
            Destroy(collision.gameObject);
        }
    }
}
