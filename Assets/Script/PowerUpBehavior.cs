using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBehavior : MonoBehaviour
{
    public bool Heal;
    public bool HealthUpgrade;
    public bool CooldownUpgrade;
    public bool GunAdd;
    public bool ProjSpeedUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Heal && other.CompareTag("Bullet"))
        {
            PlayerMechanics.Health = PlayerMechanics.Health + 10;
            AudioManagerScript.playBoost = true;
            Destroy(gameObject);
        }

        if (HealthUpgrade && other.CompareTag("Bullet"))
        {
            PlayerMechanics.MaxHealth = PlayerMechanics.MaxHealth + 50;
            PlayerMechanics.Health = PlayerMechanics.Health + 25;
            PowerUpTextScript.HealthTextDisplay = true;
            AudioManagerScript.playBoost = true;
            Destroy(gameObject);
        }

        if (CooldownUpgrade && other.CompareTag("Bullet") && ShootingScript.cooldown > 0.25)
        {
            ShootingScript.cooldown = ShootingScript.cooldown - 0.25f;
            PowerUpTextScript.CooldownTextDisplay = true;
            AudioManagerScript.playBoost = true;
            Destroy(gameObject);
        }

        if (GunAdd && other.CompareTag("Bullet"))
        {
            PowerUpManager.CurrentGunAmount = PowerUpManager.CurrentGunAmount + 1;
            PowerUpTextScript.GunAddTextDisplay = true;
            AudioManagerScript.playBoost = true;
            Destroy(gameObject);
        }

        if (ProjSpeedUpgrade && other.CompareTag("Bullet") && PlayerProjectile.force < 45)
        {
            PlayerProjectile.force = PlayerProjectile.force + 5;
            PowerUpTextScript.SpeedTextDisplay = true;
            AudioManagerScript.playBoost = true;
            Destroy(gameObject);
        }
    }
}
