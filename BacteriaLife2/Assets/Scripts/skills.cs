using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class skills : MonoBehaviour
{
    GameObject Player_Overlay;
    public int count_speed, count_endurance;

    public void Speed()
    {
        Player_Overlay = GameObject.FindGameObjectWithTag("Overlay0");
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna > 0)
        {
            count_speed += 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().speed = (Mathf.Sqrt(0.2f * count_speed) + 0.6f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna -= 1;
            Player_Overlay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DNA: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna;
            Player_Overlay.transform.GetChild(6).GetChild(4).GetComponent<TextMeshProUGUI>().text = "Speed: " + count_speed;
        }

    }

    public void Endurance() 
    {
        Player_Overlay = GameObject.FindGameObjectWithTag("Overlay0");
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna > 0)
        {
            count_endurance += 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().endurance = (Mathf.Sqrt(0.2f * count_endurance) + 0.6f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna -= 1;
            Player_Overlay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DNA: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna;
            Player_Overlay.transform.GetChild(6).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Endurance: " + count_endurance;
        }
    }

    public void Return()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewCamera>().pause = false;
        this.gameObject.SetActive(false);
    }
}
