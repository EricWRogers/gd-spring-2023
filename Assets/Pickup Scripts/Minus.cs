using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus : MonoBehaviour
 {
 
    private int count = 0;
    public float timer = 0f;
    public float waitTime = 10f;
    WaterBarController waterBarController;
    public float waterMinus = 20f;
    
    void Awake()
    {
        waterBarController = FindObjectOfType<WaterBarController>();
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        timer += Time.fixedDeltaTime;           
        if (timer >= waitTime)
        {
            if (other.tag == "Player"){
                count++;            
                timer -= waitTime + Time.fixedDeltaTime;
                waterBarController.fill -= waterMinus;
            }
           
        } 
    }
 }