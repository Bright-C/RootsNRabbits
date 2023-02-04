using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RabbitMovement : MonoBehaviour
{
    public float maximumVelocity = 5;
    public float speedMultiplier = 10;
    public float slowdownMultiplier = 10;
    [SerializeField] Rigidbody2D _myRigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = InputManager.Instance.InputActions.Player.Move.ReadValue<Vector2>();
        _myRigidbody.AddForce(movement * speedMultiplier * Time.deltaTime);
        if (_myRigidbody.velocity.x > maximumVelocity)
        {
            _myRigidbody.AddForce(new Vector2(-slowdownMultiplier * Time.deltaTime, 0));
        }

    }

    private void FixedUpdate()
    {

    }
}
