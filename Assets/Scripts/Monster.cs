using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{
    public int MaxHealth;
    public Sprite[] Sprites;

    private int Health;

    private const float SPEED = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // distance between player and this monster
        float distance = Vector2.Distance(Player.PlayerObject.transform.position, transform.position);

        if (distance <= 80) // player is near, move towards 
        {
            // angle between monster and player 
            float angle = Random.Range(-1.5f, 1.5f) + Mathf.Atan2(Player.PlayerObject.transform.position.y - transform.position.y, Player.PlayerObject.transform.position.x - transform.position.x);
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * SPEED; // move towards player
        }
        else // player is far, walk around
        {
            // random angle
            float angle = Random.Range(0, Mathf.PI * 2f); 
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * SPEED; // move around
        }
        
    }
    
    public void Damage(int dmg) // item get damage
    {
        Health -= dmg;
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
        else  // item is still alive, change sprite
        {
            //GetComponent<SpriteRenderer>().sprite = Sprites[Health ];
        }
    }

   // private void OnCollisionEnter2D(Collision2D other)
   // {
   //     if (other.gameObject.CompareTag("Player")) Player.PlayerObject.Defeat(); // kill player
   // }    
}


