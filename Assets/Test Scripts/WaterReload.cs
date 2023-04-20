using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
            waterBarController.curCap = waterBarController.curCap + waterAdd;
        }
    }

}
