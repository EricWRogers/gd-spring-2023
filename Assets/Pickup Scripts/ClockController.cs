using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public AudioClip clockSound;
    Timer timer;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer.timeLeft += 5.0f;
            AudioSource.PlayClipAtPoint(clockSound, transform.position);
            Destroy(gameObject);
        }
    }

}
