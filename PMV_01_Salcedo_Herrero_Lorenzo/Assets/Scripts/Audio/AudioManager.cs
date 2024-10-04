using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource audioSourceObjetos; 
    public AudioClip coinPickUpSound;

    private void Awake() {
        instance = this;
    }

    public static void PlayCoinPickUpSound()
    {
        instance.audioSourceObjetos.PlayOneShot(instance.coinPickUpSound);
    }
}
