using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip collectSound;
    public void Collect()
    {
        Destroy(gameObject);
        LevelManager.Instance.CollectSeed();
        SFXPlayer.Instance.PlayAudio(collectSound);
    }
}
