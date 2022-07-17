using UnityEngine;

namespace Penguin
{
    public class RunState : PenguinState
    {
        private readonly int _animParamId = Animator.StringToHash("Run");
        public RunState(PenguinController penguin) : base(penguin) { }

        public override void Start()
        {
            penguin.animator.SetTrigger(_animParamId);
        }

        public override void Update()
        {
            if (penguin.settings.rawInput.x == 0 || penguin.lockAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.idleState);
    
            else if (penguin.settings.rawInput.y < -0.5f && Mathf.Abs(penguin.rigidbody.velocity.x) > penguin.settings.Speed / 2)
                penguin.ChangeState(penguin.slideState);
    
            else if (penguin.jumpAction.WasPressedThisFrame() && penguin.Grounded)
                penguin.ChangeState(penguin.jumpState);
            
            else if (penguin.attackAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.meleeAttackState);
        }

        public override void FixedUpdate()
        {
            penguin.rigidbody.velocity = new Vector2(penguin.settings.smoothInput.x * penguin.settings.Speed, penguin.rigidbody.velocity.y);
        }

        public override string ToString() => "Running";
    }
}
