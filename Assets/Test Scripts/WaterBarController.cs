using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBarController : MonoBehaviour
{
    [SerializeField]
    Slider waterBar;
    [SerializeField]
    Text waterText;

    public float curCap;

    // Start is called before the first frame update
    void Start()
    {
        curCap = waterBar.value;
        
    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Pickup")
        {
            waterBar.value += 10f;
            curCap = waterBar.value;

        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
