using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject gm;
    private WaterPercentage Wp;

    private void Start()
    {
        Wp = GameObject.Find("Canvas").GetComponent< WaterPercentage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Wp.score += 5f;
            Destroy(gameObject);
        }
    }

}
