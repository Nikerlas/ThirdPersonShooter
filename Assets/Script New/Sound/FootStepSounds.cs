using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{
    public AudioSource playerFootAudio;
    public AudioClip footClip;

    void Start()
    {
        
    }

    public void PlayFootSound()
    {
        playerFootAudio.PlayOneShot(footClip);
    }
}
