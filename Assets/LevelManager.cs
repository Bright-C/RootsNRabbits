using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : GameObjectSingleton<LevelManager>
{
    public int availableSeeds = 0;
    UnityEvent onCollectSeed;
    public UnityEvent onWinLevel;
    public UnityEvent onLoseLevel;
    [SerializeField] AudioClip wonLevelAudio;
    [SerializeField] AudioClip loseLevelAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasSeeds()
    {
        return availableSeeds > 0;
    }

    public void CollectSeed()
    {
        availableSeeds++;
        onCollectSeed?.Invoke();
    }

    public void ConsumeSeed()
    {
        availableSeeds--;
    }

    public void WinLevel()
    {
        onWinLevel?.Invoke();
        SFXPlayer.Instance.PlayAudio(wonLevelAudio);
    }

    public void LoseLevel()
    {
        onLoseLevel?.Invoke();
        SFXPlayer.Instance.PlayAudio(loseLevelAudio);
        Destroy(GameObject.FindWithTag("Player"));
    }
}
