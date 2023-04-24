using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterPercentage : MonoBehaviour
{
    public TMP_Text textScore;
    public float score;


    void Start()
    {
        score = 0f;
        textScore.text = score.ToString() + "% Water Capacity";
        
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = score.ToString() + "% Water Capacity";
    }
}
