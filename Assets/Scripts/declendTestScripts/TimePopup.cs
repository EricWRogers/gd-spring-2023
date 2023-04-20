using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePopup : MonoBehaviour
{

    public float destroyTime = 3f;
    public Vector3 Offset = new Vector3(0, 0, 0);
    public Vector3 RandomizeIntensity = new Vector3(0, 0 ,0);
    void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(RandomizeIntensity.x,RandomizeIntensity.x),
        Random.Range(RandomizeIntensity.y,RandomizeIntensity.y),
        Random.Range(RandomizeIntensity.z,RandomizeIntensity.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
