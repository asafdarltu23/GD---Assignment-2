using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManagerScript : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip sound;
    public static bool playExplosion = false;
    public static bool playBoost = false;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.clip = sound;
    }

    // Update is called once per frame
    void Update()
    {
        if (playExplosion == true && this.name == "ExplosionAudio")
        {
            audioPlayer.Play();
            playExplosion = false;
        }

        if (playBoost == true && this.name == "BoostAudio")
        {
            audioPlayer.Play();
            playBoost = false;
        }
    }
}
