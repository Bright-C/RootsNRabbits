using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVelocityOnAnimator : MonoBehaviour
{
    public float moveThreshold = 0.1f;
    [SerializeField] SpriteRenderer mySprite;
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] Animator targetAnimator;
    string idleAnimation = "idle";
    string walkAnimation = "walk";
    string jumpAnimation = "jump";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myRigidbody.velocity.x < -moveThreshold)
        {
            mySprite.flipX = true;
            targetAnimator.Play(walkAnimation);
        }
        else if (myRigidbody.velocity.x > moveThreshold)
        {
            mySprite.flipX = false;
            targetAnimator.Play(walkAnimation);
        }
        else
        {
            targetAnimator.Play(idleAnimation);
        }
    }
}
