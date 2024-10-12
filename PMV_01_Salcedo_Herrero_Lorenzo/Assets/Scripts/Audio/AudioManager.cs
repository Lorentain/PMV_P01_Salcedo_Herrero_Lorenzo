using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource audioSourceObjetos;
    public AudioClip coinPickUpSound;
    public AudioClip openDoorSound;
    public AudioClip lockDoorSound;
    public AudioClip keyPickUpSound;

    private void Awake()
    {
        instance = this;
    }

    public static void PlayCoinPickUpSound()
    {
        instance.audioSourceObjetos.PlayOneShot(instance.coinPickUpSound);
    }

    public static void PlayKeyPickUpSound()
    {
        instance.audioSourceObjetos.PlayOneShot(instance.keyPickUpSound);
    }

    public static void PlayOpenDoorSound()
    {
        instance.audioSourceObjetos.PlayOneShot(instance.openDoorSound);
    }

    public static void PlayLockDoorSound()
    {
        instance.audioSourceObjetos.PlayOneShot(instance.lockDoorSound);
    }
}
