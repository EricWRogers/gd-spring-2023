using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaLikeMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public List<string> tagsJump;
    public List<string> tagsWall;
    public Vector2 move;
    public float moveSpeed = 1.0f;
    public Vector2 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public int wallCollisionData = 0;
    public int movementDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector2(0.0f, 2.0f);
        move = new Vector2(1.0f, 0.0f);
        //rb.AddForce(-move * moveSpeed, ForceMode2D.Force);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (tagsJump.Contains(other.gameObject.tag))
        {
            isGrounded = true;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (tagsWall.Contains(other.gameObject.tag))
        {
            /*List<ContactPoint2D> hits = new List<ContactPoint2D>();
            other.GetContacts(hits);
            ContactPoint2D closetPoint = new ContactPoint2D();
            float closetDistance = float.MaxValue;
            
            foreach(ContactPoint2D cp2d in hits)
            {
                Debug.Log("check");
                if (Vector2.Distance((Vector2)transform.position, cp2d.point) < closetDistance)
                {
                    Debug.Log("CD" + cp2d.point);
                    closetDistance = Vector2.Distance((Vector2)transform.position, cp2d.point);
                    closetPoint = cp2d;
                }
            }*/

            Vector2 direction = (Vector2)other.gameObject.transform.position - (Vector2)transform.position;

            //wallCollisionData = (int)direction.normalized.x;
            // variable = condition ? true : false;
            wallCollisionData = (direction.x < 0) ? -1 : 1;
        }
    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

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

