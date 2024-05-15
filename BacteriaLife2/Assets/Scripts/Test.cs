using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float move_x = 0, move_y = 0;
    public float food;
    public int health;
    [SerializeField] float speed;
    void Start()
    {
        food = 4; health = 10;
    }

    void Update()
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
       
        if (Input .GetKey(KeyCode.D))
        {
            move_x = 1;
        }
        else if (Input .GetKey(KeyCode.A))
        {
            move_x = -1;
        }
        else
        {
            move_x = 0;
        }
        
    }
    private void FixedUpdate()
    {
        if (food > 0)
            food -= 0.01f;
        else
            health -= 1;


        transform.position += new Vector3(move_x, move_y, 0) * (speed / 10);
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
