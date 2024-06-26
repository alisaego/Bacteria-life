using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class lose_game : MonoBehaviour

{
    GameObject Player_Overlay;
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void Lose_game()
    {
        
        gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewCamera>().pause = true;
    }
    public void restart()
    {
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().food = 4;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().health = 10;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().score = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().speed = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().endurance = 1;

        Player_Overlay = GameObject.FindGameObjectWithTag("Overlay0");
        Player_Overlay.transform.GetChild(6).GetChild(0).GetComponent<skills>().count_speed = 0;
        Player_Overlay.transform.GetChild(6).GetChild(0).GetComponent<skills>().count_endurance = 0;

        Collider2D[] col = Physics2D.OverlapCircleAll(this.transform.position, 20f);
        foreach (Collider2D go in col)
        {
            if (go.tag == "grass")
            {
                Destroy(go.gameObject);
            }
            if (go.tag == "mob")
            {
                Destroy(go.gameObject);
            }
        }
        
    }
}
