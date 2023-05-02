using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSprayScript : MonoBehaviour
{
    public const float WATER_MAX_COOLDOWN = 0.2f;
    private float WaterCooldown;
    public ParticleSystem pSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
                // repurposed Water Shooting Controls

                if (WaterCooldown > 0) WaterCooldown -= Time.deltaTime;

                if (WaterCooldown <= 0)
                {
                    if (Input.GetKey(KeyCode.Mouse0)) // cast while button is hold
                    {
                        WaterCooldown = WATER_MAX_COOLDOWN;

                        
                        pSystem.Play();
                        
                        GameObject projectile = Instantiate(Resources.Load("Water")) as GameObject;
                       
                       projectile.transform.position = transform.position; // set position to position of player 
                       projectile.GetComponent<Projectile>().Speed = 20;
                       projectile.GetComponent<Projectile>().Angle = Mathf.Atan2(Input.mousePosition.y - Screen.height / 2f, Input.mousePosition.x - Screen.width / 2f); // aim with a mouse from screen center
                      
                    }
                    else
                    {
                        pSystem.Stop();
                    }
                    
                }
            }
    }

