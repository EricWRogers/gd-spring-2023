using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Angle; // in rad

    private Transform _transform; 
    
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle)) * Speed;
        _transform.position = _transform.position + (velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<Monster>().Damage(1);
            Destroy(gameObject); //remove this projectile from the game
        }   
        else if (other.CompareTag("Item"))
        {
            other.GetComponent<DestructibleItem>().Damage(1);
            Destroy(gameObject); //remove this projectile from the game
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject); //remove this projectile from the game
        }    
    }
}
