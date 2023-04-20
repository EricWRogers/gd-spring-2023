using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveDoorWhenTriggered : MonoBehaviour
{
    public Transform AffectedObject;
    public bool ReturnDoorOnRelease;
    public Vector2 EndPosition;
    public float Speed;

    private Vector2 StartPosition; 
    private bool PressurePlatePressed;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = AffectedObject.position;
    }

   private void FixedUpdate()
    {
        if (GetComponent<Collider2D>().IsTouchingLayers(1)) SetPressurePlateState(true);
        else SetPressurePlateState(false);

        if (PressurePlatePressed)
        {
            AffectedObject.position = Vector2.MoveTowards(AffectedObject.position, EndPosition,  Speed * Time.fixedDeltaTime);
        }
        else // button is not pressed 
        {
            if (ReturnDoorOnRelease)
            {
                AffectedObject.position = Vector2.MoveTowards(AffectedObject.position, StartPosition,  Speed * Time.fixedDeltaTime);
            }
        }
    }
    
    private void SetPressurePlateState(bool newState)
    {
        if (PressurePlatePressed != newState)
        {
            PressurePlatePressed = newState; 
            
            // change pressure plate appearance (pressed or not)
            if (PressurePlatePressed) transform.Find("Surface").localPosition = new Vector3(x: 0, y: 0, z: 1); // pressed
            else transform.Find("Surface").localPosition = new Vector3(x: 0, y: 0.05f, z: 1); // unpressed
        }    
    }
}