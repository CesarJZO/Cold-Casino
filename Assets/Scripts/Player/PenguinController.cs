using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PenguinController : MonoBehaviour
{
    [Header("Dependencies")]
    private Rigidbody2D _rigidbody;
    
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _jumpAction;

    #region State Machine

    private StateMachine _stateMachine;
    public Idle idle;
    public Jump jump;
    public Slide slide;

    public void ChangeState(State state) => _stateMachine.ChangeState(state);
    
    #endregion
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];

        _stateMachine = new StateMachine();
        idle = new Idle(this);
        jump = new Jump(this);
        slide = new Slide(this);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    public override string ToString() => $"Name: {gameObject.name}";
}