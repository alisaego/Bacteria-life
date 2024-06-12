using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class back : MonoBehaviour
{
    GameObject img1, img2;
    [SerializeField] float speed;

    public void Start()
    {
        img1 = transform.GetChild(0).gameObject;
        img2 = transform.GetChild(1).gameObject;
    }
    private void FixedUpdate()
    {
        img1.transform.position += new Vector3(0, 1, 0) * (speed / 10);
        img2.transform.position += new Vector3(0, 1, 0) * (speed / 10);
        if (img1.transform.position.y > -10.54)
            img1.transform.position = new Vector3(0, 10.76f, 0);
    }
}
