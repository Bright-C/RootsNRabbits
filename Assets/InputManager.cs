using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : GameObjectSingleton<InputManager>
{
    DefaultActions _inputActions;
    public DefaultActions InputActions
    {
        get { return _inputActions; }
    }


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        _inputActions = new DefaultActions();
        _inputActions.UI.Enable();
        _inputActions.Player.Enable();

    }

    // Update is called once per frame
    void Update()
    {

    }
}