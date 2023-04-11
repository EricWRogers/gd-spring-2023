using System;
using UnityEngine;


    public class Player : MonoBehaviour
    {
        public static Player PlayerObject;
        private const float PLAYER_SPEED = 15;       
        private const float WATER_MAX_COOLDOWN = 0.2f;
        private float WaterCooldown;
        private bool Alive = true;
            
        // Start is called before the first frame update
        void Start()
        {
            PlayerObject = this;
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
 
        private void FixedUpdate()
        {
            //moving controls
            if (Alive)
            {
                float moveX = Input.GetAxis("Horizontal");
                float moveY = Input.GetAxis("Vertical");
                Vector2 newVelocity = new Vector2(moveX, moveY).normalized * PLAYER_SPEED;

                Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = newVelocity;
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

   
