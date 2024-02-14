using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpTextScript : MonoBehaviour
{
    //Referenced by Behavior script
    public static bool HealthTextDisplay;
    public static bool GunAddTextDisplay;
    public static bool CooldownTextDisplay;
    public static bool SpeedTextDisplay;

    public GameObject HealthText;
    public GameObject GunText;
    public GameObject CooldownText;
    public GameObject SpeedText;
    //public GameObject textToDisplay;
    float timer;
    float duration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthTextDisplay == true && PlayerMechanics.MaxHealth <= 500)
        {
            HealthText.SetActive(true);
            timer += Time.deltaTime;
            if (timer > duration)
            {
                HealthText.gameObject.SetActive(false);
                HealthTextDisplay = false;
                timer = 0;
            }
        }

        if (GunAddTextDisplay == true && PowerUpManager.CurrentGunAmount < 4)
        {
            GunText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > duration)
            {
                GunText.gameObject.SetActive(false);
                GunAddTextDisplay = false;
                timer = 0;
            }
        }

        if (CooldownTextDisplay == true)
        {
            CooldownText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > duration)
            {
                CooldownText.gameObject.SetActive(false);
                CooldownTextDisplay = false;
                timer = 0;
            }
        }

        if (SpeedTextDisplay == true)
        {
            SpeedText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > duration)
            {
                SpeedText.gameObject.SetActive(false);
                SpeedTextDisplay = false;
                timer = 0;
            }
        }

    }
}
