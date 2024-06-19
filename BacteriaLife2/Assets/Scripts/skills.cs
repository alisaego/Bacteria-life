using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class skills : MonoBehaviour
{
    GameObject Player_Overlay;
    int count_speed, count_endurance;

    public void Speed()
    {
        Player_Overlay = GameObject.FindGameObjectWithTag("Overlay0");
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().speed *= 1.01f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna -= 1;
            count_speed += 1;
            Player_Overlay.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Speed: " + count_speed;
        }

    }

    public void Endurance() 
    {
        Player_Overlay = GameObject.FindGameObjectWithTag("Overlay0");
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().endurance *= 1.01f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna -= 1;
            count_endurance += 1;
            Player_Overlay.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "Endurance: " + count_endurance;
        }
    }

    public void Return()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewCamera>().pause = false;
        this.gameObject.SetActive(false);
    }
}
