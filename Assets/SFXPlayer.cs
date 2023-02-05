using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : GameObjectSingleton<SFXPlayer>
{
    [SerializeField] AudioSource source;
    public void PlayAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
