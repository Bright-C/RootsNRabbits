using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithGoalBehaviour : InteractWithCollisionBehaviour<Goal>
{
    override protected void OnTriggerEnterInteraction(Goal goal)
    {
        goal.ReachGoal();
    }
}
