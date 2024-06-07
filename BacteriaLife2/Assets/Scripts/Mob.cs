using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Mob : MonoBehaviour
{
    public float[] weight = new float[3];
    public GameObject target;
    public float speed, health = 20, food;

    private void Start()
    {
        weight[0] = 0.5f + Random.Range(-0.10f, 0.10f);
        weight[1] = -0.5f + Random.Range(-0.10f, 0.10f);
        weight[2] = -0.5f + Random.Range(-0.10f, 0.10f);
    }
    private void FixedUpdate()
    {
        
        if (target != null)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed / 15);
        }
        else
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(this.transform.position, 10f);
            float maxP = -1000;
            foreach (Collider2D go in col)
            {
                if (go.tag == "grass")
                {
                    float r = GetPrice(go.gameObject);
                    if (r > maxP)
                    {
                        maxP = r;
                        target = go.gameObject;
                    }
                }
            }
        }

        if (food > 0)
            food -= 0.1f;
        else
            health -= 1;
        if (food > 50)
        {
            food -= 20f;
            Instantiate(this.gameObject);
        }
        if (health < 0)
            Destroy(gameObject);
    }
    float GetPrice(GameObject tar)
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(tar.transform.position, 3f);
        int countMob = 0, countGrass = 0;
        float r = 0;
        foreach (Collider2D go in col) 
        {
            if (go.gameObject.tag == "grass")
                countGrass += 1;
            if (go.gameObject.tag == "mob" || go.gameObject.tag == "Player")
                countMob += 1;
        }
        r += countGrass * weight[0];
        r += countMob * weight[1];
        r += Vector2.Distance(tar.transform.position, this.transform.position) * weight[2];

        return r;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grass")
        {
            food += 10f;
            Destroy(collision.gameObject);
        }
    }

  

}
