using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public List<string> tagsWall;
    public Vector2 move;
    public float moveSpeed = 1.0f;
    public int wallCollisionData = 0;
    public int movementDirection = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = new Vector2(1.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (tagsWall.Contains(other.gameObject.tag))
        {

            Vector2 direction = (Vector2)other.gameObject.transform.position - (Vector2)transform.position;

            wallCollisionData = (direction.x < 0) ? -1 : 1;
        }
    }

    void FixedUpdate()
    {
        if (wallCollisionData != 0)
        {
            movementDirection = wallCollisionData * -1;

            wallCollisionData = 0;
        }

        Vector2 velocity = rb.velocity;
        velocity.x = movementDirection * moveSpeed;
        rb.velocity = velocity;
    }
}
