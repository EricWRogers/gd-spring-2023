using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;
    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    void FixedUpdate()
    {
        //camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        //camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z), smoothSpeed);
        this.transform.position = smoothPos;


    }
}

// To use, put the script on the main camera, and drag the player object into the "Follow Transform" box
// To restrict camera movement, create an object with a Box Collider 2D, resize it to the correct size, and drag the object into the "Map Bounds" box, make sure to make box collider "is trigger"
//If you have any questions, ask Connor