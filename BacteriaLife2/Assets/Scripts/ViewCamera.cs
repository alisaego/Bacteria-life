using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCamera : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject grass_teamplate;
    [SerializeField] GameObject mob_teamplate;
    public bool pause;


    public void MenuSkills()
    {
        pause = !pause;
        GameObject.FindGameObjectWithTag("Overlay0").transform.GetChild(6).gameObject.SetActive(true);
    }
    public void ChangesPause()
    {
        pause = !pause;
        GameObject.FindGameObjectWithTag("Overlay0").transform.GetChild(4).gameObject.SetActive(true);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            float dist = Vector2.Distance(this.transform.position, player.transform.position);
            if (dist > 4f)
            {
                this.transform.position += (player.transform.position + new Vector3(0, 0, -10) - this.transform.position) * (dist - 4) / 90;
            }
        }
        if (Time.time % 1 == 0 && pause == false)
        {
            for (int i = 1; i < 6; i++)
            {

                GameObject a = Instantiate(grass_teamplate);
                float pos_x = 0, pos_y = 0;
                int var = Random.Range(0, 4);
                if (var == 0)
                {
                    pos_x = Random.Range(-20f, 20f);
                    pos_y = Random.Range(-9f, -6f);
                }
                else if (var == 1)
                {
                    pos_x = Random.Range(-17f, -12f);
                    pos_y = Random.Range(-10f, 10f);
                }
                else if (var == 2)
                {
                    pos_x = Random.Range(-20f, 20f);
                    pos_y = Random.Range(6f, 9f);
                }
                else if (var == 3)
                {
                    pos_x = Random.Range(12f, 17f);
                    pos_y = Random.Range(-10f, 10f);
                }
                a.transform.position = GameObject.FindWithTag("MainCamera").transform.position + new Vector3(pos_x, pos_y, 10);
            }
        }
        if (Time.time % 5 == 0 && pause == false)
        {
            for (int i = 1; i < 5; i++)
            {

                GameObject a = Instantiate(mob_teamplate);
                float pos_x = 0, pos_y = 0;
                int var = Random.Range(0, 4);
                if (var == 0)
                {
                    pos_x = Random.Range(-20f, 20f);
                    pos_y = Random.Range(-9f, -6f);
                }
                else if (var == 1)
                {
                    pos_x = Random.Range(-17f, -12f);
                    pos_y = Random.Range(-10f, 10f);
                }
                else if (var == 2)
                {
                    pos_x = Random.Range(-20f, 20f);
                    pos_y = Random.Range(6f, 9f);
                }
                else if (var == 3)
                {
                    pos_x = Random.Range(12f, 17f);
                    pos_y = Random.Range(-10f, 10f);
                }
                a.transform.position = GameObject.FindWithTag("MainCamera").transform.position + new Vector3(pos_x, pos_y, 10);
            }
        }
    }

}


