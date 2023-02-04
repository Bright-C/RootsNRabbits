using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RabbitMovement : MonoBehaviour
{
    public float maximumVelocity = 5;
    public float speedMultiplier = 10;
    public float AirSlowdown
    {
        get 
        {
            return isGrounded ? 1f : 0.5f;
        }
    }
    public float jumpForce = 200;
    public float jumpCooldown = 0.5f;
    public float jumpCooldownCount = 0;
    public float slowdownMultiplier = 10;
    public float castDistance = 0.1f;
    public bool isGrounded;
    public ContactFilter2D myContactFilter;
    [SerializeField] Rigidbody2D _myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.InputActions.Player.Jump.performed += JumpPerformed;
    }

    private void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (obj.ReadValueAsButton())
        {
            if (isGrounded && jumpCooldownCount == 0)
            {
                jumpCooldownCount = jumpCooldown;
                _myRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = InputManager.Instance.InputActions.Player.Move.ReadValue<Vector2>();
        movement.y = 0;
        _myRigidbody.AddForce(movement * speedMultiplier * Time.deltaTime * AirSlowdown);
        if (_myRigidbody.velocity.x > maximumVelocity)
        {
            _myRigidbody.AddForce(new Vector2(-slowdownMultiplier * Time.deltaTime, 0));
        }

    }

    private void FixedUpdate()
    {
        //grounding
        List<RaycastHit2D> results = new();
        _myRigidbody.Cast(Vector2.down, results, castDistance);
        if (results.Count > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //jumping
        if (jumpCooldownCount > 0)
        {
            jumpCooldownCount -= Time.fixedDeltaTime;
        }
        else
        {
            jumpCooldownCount = 0;
        }
    }
}
