using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterBarController : MonoBehaviour
{
    [SerializeField]
    Slider waterBar;
    [SerializeField]
    TMP_Text waterText;

    public float curCap;
    public float fill;
    public float overTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        curCap = waterBar.maxValue;
    }


    // Update is called once per frame
    void Update()
    {
        fill = Mathf.Clamp(fill, waterBar.minValue, waterBar.maxValue);
        waterText.text = (Mathf.Floor((fill/curCap)*100.0f)).ToString() + "% Water Capacity";
        waterBar.value = fill;
    }
}
