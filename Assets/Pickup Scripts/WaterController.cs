using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject gm;
    public WaterPercentage Wp;
    public AudioClip waterSound;
    void Start()
    {
        Wp = GameObject.Find("Canvas").GetComponent< WaterPercentage>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Wp.score += 5f;
            AudioSource.PlayClipAtPoint(waterSound, transform.position);
            Destroy(gameObject);
        }
    }

}
