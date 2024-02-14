using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public static int Health = 100;
    public static float CooldownBuff = 1;
    public static int GunAmountBuff;
    public static int MaxHealth = 100;
    public static float projectileSpeedBuff = 1;

    float currentHealth;

    public GameObject Camera;
    public float duration = 0.5f;

    public GameObject ScreenEffect;

    public HealthBarScript healthBar;

    public AudioSource audioPlayer;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Health;
        healthBar.setMaxHealth(MaxHealth);
        audioPlayer.clip = sound;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(Health);
        healthBar.setMaxHealth(MaxHealth);

        if (Health < currentHealth)
        {
            currentHealth = Health;
            StartCoroutine(Red());
            audioPlayer.Play();
        }

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        if (MaxHealth > 500)
        {
            MaxHealth = 500;
        }
    }

    IEnumerator Red()
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {           
            elapsedTime += Time.deltaTime;
            ScreenEffect.SetActive(true);
            yield return null;
        }

       ScreenEffect.SetActive(false);

    }
}
