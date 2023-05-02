using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water_Remove : MonoBehaviour
{
    WaterBarController waterBarController;

    public float waterMinus = 20f;

    // Start is called before the first frame update
    void Awake()
    {
        waterBarController = FindObjectOfType<WaterBarController>();
    }
   

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");
        if (other.tag == "Player")
        {
            Debug.Log("Subtract water");
            waterBarController.fill -= waterMinus;  
        }
    }

}