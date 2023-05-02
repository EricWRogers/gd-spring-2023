using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterPercentage : MonoBehaviour
{
    public TMP_Text textScore;
    public float score;
    public WaterBarController waterBC;

    void Awake()
    {
        //waterBC = FindObjectOfType<WaterBarController>();
    }


    void Start()
    {
        score = 0f;
        //score = score + waterBC.curCap;
        //textScore.text = score.ToString() + "% Water Capacity";
        
    }

    // Update is called once per frame
    void Update()
    {
        //textScore.text = score.ToString() + "% Water Capacity";
    }
}
