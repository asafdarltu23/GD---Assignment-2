using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static float CurrentGunAmount = 2;
    public GameObject Gun3;
    public GameObject Gun4;

    float timer1;
    float timer2;
    float maxTime = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Reset cooldown upgrades
        if (ShootingScript.cooldown != 1)
        {
            timer1 += Time.deltaTime;
            if (timer1 > maxTime)
            {
                ShootingScript.cooldown = 1;
                timer1 = 0;
            }
        }
        //Reset projectile speed upgrades
        if (PlayerProjectile.force != 15)
        {
            timer2 += Time.deltaTime;
            if (timer2 > maxTime)
            {
                PlayerProjectile.force = 15;
                timer2 = 0;
            }
        }

        if (CurrentGunAmount == 3)
        {
            Gun3.SetActive(true);
        }
        else if (CurrentGunAmount == 4)
        {
            Gun4.SetActive(true);
        }
    }
}
