using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    //orientation
    private Vector2 _normal = new Vector2(0,1);
    private Vector2 _lastPosition;
    private float _epsilonPosition = 0.1f;
    private bool _orientated = false;
    [SerializeField] AudioClip jumpAudio;



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
                SFXPlayer.Instance.PlayAudio(jumpAudio);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = InputManager.Instance.InputActions.Player.Move.ReadValue<Vector2>();
        movement.y = 0;
        if (Mathf.Abs(_myRigidbody.velocity.x) < maximumVelocity)
        {
            _myRigidbody.AddForce(movement * speedMultiplier * Time.deltaTime * AirSlowdown);
            //_myRigidbody.AddForce(new Vector2(slowdownMultiplier * Time.deltaTime * -_myRigidbody.velocity.x, 0));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CalcNormal(collision);
        Orientate();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CalcNormal(collision);
        Orientate();
    }

    private void CalcNormal(Collision2D collision)
    {
        if((_myRigidbody.position - _lastPosition).magnitude < _epsilonPosition)
        {
            if(!_orientated)
            {
                _orientated = true;
            }
            else
            {
                _orientated = false;
                return;
            }
        }
        _lastPosition = _myRigidbody.position;

        List<ContactPoint2D> contacts = new();
        collision.GetContacts(contacts);
        if (contacts.Count > 0)
        { 
            int index = 0;
            float maxY = float.MinValue;
            for (int i = 0; i < contacts.Count; ++i)
            {
                if (contacts[i].normal.y > maxY)
                {
                    maxY = contacts[i].normal.y;
                    index = i;
                }
            }
            _normal = contacts[index].normal;
        }
    }

    private void Orientate()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _normal);
    }
}
