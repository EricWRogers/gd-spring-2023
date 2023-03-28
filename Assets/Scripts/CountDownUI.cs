using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownUI : MonoBehaviour
{
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        TMP_Text tmpText = GetComponent<TMP_Text>();

        if(tmpText == null || timer == null)
        {
            Debug.LogWarning("tmpText or timer is null");
            return;
        }

        // seconds from timeLeft
        int seconds = Mathf.CeilToInt(timer.timeLeft) % 60;
        int min = (int)(timer.timeLeft / 60.0f);

        if(seconds > 9)
            tmpText.text = min + ":" + seconds;
        else
            tmpText.text = min + ":0" + seconds; 
    }
}
