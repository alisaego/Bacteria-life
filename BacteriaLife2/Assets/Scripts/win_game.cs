using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_game : MonoBehaviour
{

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Win_game()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Test>().dna == 100)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewCamera>().pause = false;
            gameObject.SetActive(true);
        }
        
    }
}
