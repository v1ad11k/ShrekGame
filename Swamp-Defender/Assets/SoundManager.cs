using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sound;
    public AudioSource a;

    public void OneSound()
    {
        a.clip = sound[0];
        a.Play();
    }
    public void TwoSound()
    {
        a.clip = sound[1];
        a.Play();
    }
    public void TreeSound()
    {
        a.clip = sound[2];
        a.Play();
    }
    public void FourSound()
    {
        a.clip = sound[3];
        a.Play();
    }

}
