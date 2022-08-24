using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SM;

    [SerializeField]
    private AudioSource audioSource, supAudioSource;
    [SerializeField] 
    private AudioSource audioSourceBGM; 

    [SerializeField]
    private AudioClip doorOpen, gunShot, footstep;

    [SerializeField]
    private AudioClip randomGunShot1, randomGunShot2, randomGunShot3;

    [SerializeField]
    private AudioClip thisBGM; 

    private bool isStop; 

    private void OnEnable()
    {
        if (SoundManager.SM == null)
        {
            SoundManager.SM = this; 
        }

        isStop = false; 
    }

    private void Start()
    {
        PlayBGM(); 
    }

    public void PlayBGM()
    {
        if (isStop) return;

        audioSourceBGM.clip = thisBGM;
        audioSourceBGM.Play(); 
    }

    public void CloseBGM()
    {
        if (audioSourceBGM.isPlaying)
        {
            audioSourceBGM.Stop();
        }
        else
        {
            PlayBGM(); 
        }
    }

    public void PlayDoorOpen()
    {
        if (isStop) return;

        supAudioSource.clip = doorOpen;
        supAudioSource.Play(); 
    }

    public void PlayFoot()
    {
        if (isStop) return;

        supAudioSource.clip = footstep;
        supAudioSource.Play(); 
    }

    public void FootCheck()
    {
        if (isStop) return; 

        if (!(supAudioSource.isPlaying && supAudioSource.clip == footstep))
        {
            PlayFoot(); 
        }
    }

    public void CloseFoot()
    {
        if (supAudioSource.isPlaying && supAudioSource.clip == footstep)
        {
            supAudioSource.Stop(); 
        }
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
        audioSourceBGM.Stop();
        supAudioSource.Stop(); 

        isStop = true;
    }
}
