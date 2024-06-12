using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class menu : MonoBehaviour
{
   public void Return()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewCamera>().pause = false; 
        this.gameObject.SetActive(false);
    }

    public void Exitt()
    {
        EditorApplication.isPlaying = false;
    }
}
