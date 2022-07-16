using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Penguin
{
    [Icon("Assets/Art/User Interface/penguin_icon.png")]
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
    public class PenguinController : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private float smoothTime;
        public Vector2 rawInput;
        public Vector2 smoothInput;
        private Vector2 _inputVelocity;
        
        private PlayerInput _playerInput;
        [HideInInspector] public InputAction moveAction;
        [HideInInspector] public InputAction jumpAction;
        [HideInInspector] public InputAction attackAction;
        
        
        [Header("Dependencies")]
        
        [SerializeField] private EntitySettings settings;
        public EntitySettings Settings => settings;
        [HideInInspector] public Animator animator;
        [HideInInspector] public new Rigidbody2D rigidbody;
        
        #region References

        public RaycastHit2D Grounded => Physics2D.Raycast(transform.position, Vector2.down, settings.GroundDistance, settings.GroundMask);

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
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();

            _playerInput = GetComponent<PlayerInput>();
            moveAction = _playerInput.actions["Move"];
            jumpAction = _playerInput.actions["Jump"];

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
            rawInput = moveAction.ReadValue<Vector2>();
            smoothInput = Vector2.SmoothDamp(smoothInput, rawInput, ref _inputVelocity, smoothTime);
            
            _stateMachine.CurrentState.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.FixedUpdate();
        }

        private void LateUpdate()
        {
            _stateMachine.CurrentState.LateUpdate();
        }

        private void OnDrawGizmos()
        {
            var position = transform.position;
            // Ground Raycast
            Gizmos.color = Color.green;
            Gizmos.DrawLine(position, position + Vector3.down * settings.GroundDistance);
        }
    }
}
