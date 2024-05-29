using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    float[] weight = new float[3];
    GameObject target;
    public float speed, health, food;

    private void Start()
    {
        for (int i = 0; i < weight.Length; i++)
        {
            weight[i] = Random.Range(-2f, 2f);
        }
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
            if (go.gameObject.tag == "mob")
                countMob += 1;
        }
        r += countGrass * weight[0];
        r += countMob * weight[1];
        r += Vector2.Distance(tar.transform.position, this.transform.position) * weight[2];

        return r;
    }
    
}
