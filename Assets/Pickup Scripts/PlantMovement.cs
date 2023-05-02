using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMovement : MonoBehaviour
{
    public AnimationCurve myCurve;
    public AudioClip thump;
   
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            AudioSource.PlayClipAtPoint(thump, transform.position);
        }
    }



}

