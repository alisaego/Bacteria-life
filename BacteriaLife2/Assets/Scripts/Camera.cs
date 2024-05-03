using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
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
    }
}

