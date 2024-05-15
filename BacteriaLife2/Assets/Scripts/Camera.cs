using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject grass_teamplate;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float dist = Vector2.Distance(this.transform.position, player.transform.position);
        if (dist > 4f)
        {
            transform.position += (player.transform.position + new Vector3(0, 0, -10) - this.transform.position) * (dist - 4) / 90;
        }
        if (Time.time % 1 == 0)
        {
            GameObject a = Instantiate(grass_teamplate);
            float pos_x = 0, pos_y = 0;
            int var = Random.Range(0, 5);
            if (var == 0)
            {
                pos_x = Random.Range(5f, 8f);
            }
            else if (var == 1)
            {
                pos_x = Random.Range(-8f, -5f);
            }
            a.transform.position = new Vector3(pos_x, pos_y, 0);
        }
    }
}

