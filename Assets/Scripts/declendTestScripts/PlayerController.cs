using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 40.0f;

    Rigidbody2D rb2d;
    float v = 0.0f;
    float h = 0.0f;
    public Timer timer; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update() // 60frame/1sec = 16msec 120frame/1sec = 8msec
    {
        h = Input.GetAxis("Horizontal"); // -1 - 1
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate() // 52/sec
    {
        Vector2 movement = new Vector2(h, v);
        rb2d.AddForce(movement * speed);
    }




}
