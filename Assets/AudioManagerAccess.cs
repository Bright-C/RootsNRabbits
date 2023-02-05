using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerAccess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetSFXVolume()
    {

    }

    public void SetMusicVolume(float amount)
    {
        AudioManager.Instance.SetMusicVolume(amount);
    }

    public void SetSFXVolume(float amount)
    {
        AudioManager.Instance.SetSFXVolume(amount);
    }
}
