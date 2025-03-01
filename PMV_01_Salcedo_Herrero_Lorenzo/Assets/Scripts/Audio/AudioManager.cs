using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource audioSourceObjetos;
    public AudioSource ambientMusic;
    public AudioSource audioSourceStep;
    public AudioClip coinPickUpSound;
    public AudioClip openDoorSound;
    public AudioClip lockDoorSound;
    public AudioClip keyPickUpSound;
    public AudioClip buttonClickSound;
    public AudioClip gameOverSound;
    public AudioClip stepSound;

    private void Awake()
    {
        instance = this;
    }

    public static AudioSource GetAudioSource()
    {
        return instance.audioSourceStep;
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

    public static void PlayButtonClickSound()
    {
        instance.audioSourceObjetos.PlayOneShot(instance.buttonClickSound);
    }

    public static void PlayGameOverSound()
    {
        instance.audioSourceObjetos.PlayOneShot(instance.gameOverSound);
    }

    public static void PlayStepSound()
    {
        if (!GetAudioSource().isPlaying) {
            instance.audioSourceStep.pitch = Random.Range(0.9f, 1.1f);
            instance.audioSourceStep.PlayOneShot(instance.stepSound);
        }
    }

    public static void StopMusicAmbient()
    {
        instance.ambientMusic.Stop();
    }
}
