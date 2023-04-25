using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class EnemyContact : MonoBehaviour
{
    public GameObject timePopup;
    public Timer timer;
    public int timeDown = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* *When colliding with an enemy the timer will go down
       *timeDown subtracts in seconds and is initialized at 10s 
       *Drag this script onto something you want to give damage to the player via collision
       *Drag the Timer object onto this script 
       *declendDamage is a placeholder tag it will be changed to whatever tag is given to the player 

       -Declend
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "declendDamage")
        {
            timer.Subtract(timeDown);
        }

        if(timePopup != null)
        {
            ShowFloatingText();
        }

    }

    void ShowFloatingText()
    {
       GameObject go = Instantiate(timePopup, transform.position, Quaternion.identity, transform);
       go.GetComponent<TextMeshPro>().text = "-" + timeDown.ToString();
    }

}
