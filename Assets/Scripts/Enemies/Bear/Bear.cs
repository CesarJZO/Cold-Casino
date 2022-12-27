using System;
using UnityEngine;

namespace Bear
{
    public class Bear : MonoBehaviour
    {

        public Animator animator;
        public Rigidbody2D rigidbody;
        
        private StateMachine _stateMachine;
        public AttackState attackState;
        public ChaseState chaseState;
        public WalkState walkState;

        [SerializeField]
        public GameObject projectile;

        [SerializeField]
        public float speed;

        [SerializeField] public float groundDistance;

        [
            SerializeField
        ]
        public int layerMask;

        public bool isFacingLeft;

        
        [SerializeField]
        public float offset;
        public bool isGroundedLeft => Physics2D.Raycast(transform.position + Vector3.left * offset, Vector2.down, groundDistance, layerMask);
        public bool isGroundedRight => Physics2D.Raycast(transform.position + Vector3.right * offset, Vector2.down, groundDistance, layerMask);

        public Vector2 direction;

        private void Awake()
        {

            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();

            _stateMachine = new StateMachine();
            attackState = new AttackState(this);
            chaseState = new ChaseState(this);
            walkState = new WalkState(this);

        }

        private void Update()
        {
            
        }

        public void ChangeState(State state) => _stateMachine.ChangeState(state);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            
            Gizmos.DrawLine(transform.position + Vector3.left * offset, transform.position + Vector3.left * offset + Vector3.down * groundDistance);
            
            Gizmos.DrawLine(transform.position + Vector3.right * offset, transform.position + Vector3.right * offset + Vector3.down * groundDistance);
        }
    }
}
