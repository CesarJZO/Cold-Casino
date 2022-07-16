﻿using UnityEngine;
using UnityEngine.InputSystem;

namespace Penguin
{
    [Icon("Assets/Art/User Interface/penguin_icon.png")]
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
    public class PenguinController : MonoBehaviour
    {
        [Header("Testing")] 
        public float slideTimer;
        public float drag;
        
        private Vector2 _inputVelocity;

        private Quaternion _currentRotation;
        
        private PlayerInput _playerInput;
        [HideInInspector] public InputAction moveAction;
        [HideInInspector] public InputAction jumpAction;
        [HideInInspector] public InputAction attackAction;
        [HideInInspector] public InputAction lockAction;

        [Header("Dependencies")]
        public PenguinSettings settings;
        public Collider2D headCollider;
        [HideInInspector] public Animator animator;
        [HideInInspector] public new Rigidbody2D rigidbody;
        
        #region References

        public RaycastHit2D Ceiling => Physics2D.BoxCast(transform.position, settings.CeilSize, transform.rotation.eulerAngles.z, Vector2.up, settings.CeilDistance, settings.CeilMask);
        public RaycastHit2D Grounded => Physics2D.Raycast(transform.position, Vector2.down, settings.GroundDistance, settings.GroundMask);
        public bool IsFacingRight { get; private set; } = true;

        #endregion
        
        #region State Machine

        private StateMachine _stateMachine;
        public IdleState idleState;
        public RunState runState;
        public JumpState jumpState;
        public SlideState slideState;
        public MeleeAttackState meleeAttackState;

        public PenguinState PreviousState => _stateMachine.PreviousState as PenguinState;
        public void ChangeState(PenguinState state) => _stateMachine.ChangeState(state);

        #endregion

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.sharedMaterial = settings.NoFriction;

            _playerInput = GetComponent<PlayerInput>();
            moveAction = _playerInput.actions["Move"];
            jumpAction = _playerInput.actions["Jump"];
            attackAction = _playerInput.actions["Attack"];
            lockAction = _playerInput.actions["Lock"];

            _stateMachine = new StateMachine();
            idleState = new IdleState(this);
            runState = new RunState(this);
            jumpState = new JumpState(this);
            slideState = new SlideState(this);
            meleeAttackState = new MeleeAttackState(this);
        }

        private void Start()
        {
            _stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            settings.rawInput = moveAction.ReadValue<Vector2>();
            settings.smoothInput = Vector2.SmoothDamp(settings.smoothInput, settings.rawInput, ref _inputVelocity, settings.SmoothTime);

            if (settings.smoothInput.magnitude <= settings.DeadZone)
                settings.smoothInput = Vector2.zero;
            
            var color = Color.red;
            if(Grounded)
                color = Color.green;
            Debug.DrawRay(transform.position, Vector3.down * settings.GroundDistance, color);

            if (settings.rawInput.x > 0 && (int)_currentRotation.y == 180 || settings.rawInput.x < 0 && (int)_currentRotation.y != 180)
            {
                _currentRotation.y = rigidbody.velocity.x > settings.DeadZone ? 0 : 180;
                IsFacingRight = rigidbody.velocity.x > settings.DeadZone;
            }
            
            _stateMachine.CurrentState.Update();
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(25,25,300,40), $"Current state: {_stateMachine.CurrentState}");
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.FixedUpdate();
        }

        private void LateUpdate()
        {
            _stateMachine.CurrentState.LateUpdate();
            if (!lockAction.IsPressed())
                transform.rotation = _currentRotation;
        }

        private void OnDrawGizmosSelected()
        {
            var position = transform.position;
            // Ground Raycast
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(position, position + Vector3.down * settings.GroundDistance);
            // Ceiling Boxcast
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(position, settings.CeilSize);
        }
    }
}
