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
