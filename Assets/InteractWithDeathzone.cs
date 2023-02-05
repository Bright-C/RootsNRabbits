using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDeathzone : InteractWithCollisionBehaviour<DeathZone>
{
    override protected void OnTriggerEnterInteraction(DeathZone deathZone)
    {
        LevelManager.Instance.LoseLevel();
    }
}
