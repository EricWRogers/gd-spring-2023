using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterReload : MonoBehaviour
{
    WaterBarController waterBarController;

    public float waterAdd = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        waterBarController = FindObjectOfType<WaterBarController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            waterBarController.fill += waterAdd;
            waterAdd = 0;
            Destroy(gameObject);
        }
    }

}
