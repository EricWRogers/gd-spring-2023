using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Player : MonoBehaviour
    {
        public static Player PlayerObject;
        private Rigidbody2D rb;
        public List<string> tagsJump;
        public Vector2 jump;
        public float jumpForce = 2.0f;
        public float enemyBounceMultipyer = 1.5f;
        public bool isGrounded;
        public bool isKilledEnemy;
        public float PLAYER_SPEED = 15.0f;       
        public const float WATER_MAX_COOLDOWN = 0.2f;
        private float WaterCooldown;
        private bool Alive = true;

        public GameObject boot; // Put boot object here in the inspector

    // Start is called before the first frame update
        void Start()
        {
            PlayerObject = this;
            jump = new Vector2(0.0f, 2.0f);
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Alive)
            {
                // repurposed Water Shooting Controls

                if (WaterCooldown > 0) WaterCooldown -= Time.deltaTime;

                if (WaterCooldown <= 0)
                {
                    if (Input.GetKey(KeyCode.Mouse0)) // cast while button is hold
                    {
                        WaterCooldown = WATER_MAX_COOLDOWN;
                        
                        GameObject projectile = Instantiate(Resources.Load("Water")) as GameObject;
                        projectile.transform.position = transform.position; // set position to position of player 
                        projectile.GetComponent<Projectile>().Speed = 100;
                        projectile.GetComponent<Projectile>().Angle = Mathf.Atan2(Input.mousePosition.y - Screen.height / 2f, Input.mousePosition.x - Screen.width / 2f); // aim with a mouse from screen center
                    }
                }
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (tagsJump.Contains(other.gameObject.tag))
            {
                isGrounded = true;
            }
        }
 
        void FixedUpdate()
        {
            //moving controls
            if (Alive)
            {
                float moveX = Input.GetAxis("Horizontal");
                
                Vector2 velocity = rb.velocity;
                velocity.x = Input.GetAxis("Horizontal") * PLAYER_SPEED;
                rb.velocity = velocity;

                if (Input.GetKey(KeyCode.Space) || isKilledEnemy)
                {
                    if (isGrounded || isKilledEnemy)
                    {
                        Debug.Log("Space!");
                        if (isKilledEnemy)
                            rb.AddForce(jump * jumpForce * enemyBounceMultipyer, ForceMode2D.Impulse);
                        else
                            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                        isGrounded = false;
                        isKilledEnemy = false;
                    }
                }

                if (isGrounded) //Turns boot off when on ground
                {                
                    boot.GetComponentInChildren<BoxCollider2D>().enabled = false;                
                }
                if (!isGrounded) //Turns boot on when off ground
                {
                    boot.GetComponentInChildren<BoxCollider2D>().enabled = true;                 
                }
            }    
            
            // menu controls
            if (Input.GetKeyDown(KeyCode.R)) UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
            if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
            {
                
            }

            
            
        }

        
        private new object GetComponent<T>()
        {
            throw new NotImplementedException();
        }

        public void Victory()
        {
            transform.Find("VictoryText").gameObject.SetActive(true);
            StartCoroutine(RestartLevelWithDelay(3f));
        }

    private string RestartLevelWithDelay(float v)
    {
        throw new NotImplementedException();
    }
}

   
