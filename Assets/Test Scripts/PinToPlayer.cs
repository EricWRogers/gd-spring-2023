using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinToPlayer : MonoBehaviour
{
  
 public Timer timer;
  
 void Update () 
 {
 }
  
 void OnTriggerEnter(Collider other)
 {
    if(other.gameObject.tag == "CPickUp")
    {
      Destroy(other.gameObject);
      timer.timeLeft += 10;  
    }
}
}
