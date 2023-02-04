using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithSeedBehaviour : InteractWithCollisionBehaviour<CollectibleSeed>
{
    override protected void OnTriggerEnterInteraction(CollectibleSeed collectibleSeed)
    {
        Debug.Log("TRIGGER INTERACTION");
        collectibleSeed.Collect();
    }
}
