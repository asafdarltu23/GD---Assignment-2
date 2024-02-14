using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalTime : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = PlayerPrefs.GetString("TotalTime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
