using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SM;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip doorOpen, gunShot, footstep;

    [SerializeField]
    private AudioClip randomGunShot1, randomGunShot2, randomGunShot3; 

    private bool isStop; 

    private void OnEnable()
    {
        if (SoundManager.SM == null)
        {
            SoundManager.SM = this; 
        }

        isStop = false; 
    }

    public void PlayDoorOpen()
    {
        if (isStop) return;

        audioSource.clip = doorOpen;
        audioSource.Play(); 
    }

    public void PlayRandomGunShot()
    {
        if (isStop) return;

        int randNum = Random.Range(1, 4);

        switch (randNum)
        {
            case 1: 
                audioSource.clip = randomGunShot1;
                break;
            case 2:
                audioSource.clip = randomGunShot2;
                break;
            case 3:
                audioSource.clip = randomGunShot3;
                break;
            default:
                break;
        }
        if (audioSource)
        {
            audioSource.Play(); 
        }
    }

    public void PlayGunShot()
    {
        if (isStop) return;

        audioSource.clip = gunShot;
        audioSource.Play(); 
    }

    public void StopAll()
    {
        audioSource.Stop();

        isStop = true;
    }
}
