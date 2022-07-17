using UnityEngine;

namespace Penguin
{
    public class JumpState : PenguinState
    {
        private readonly int _animParamId = Animator.StringToHash("Jump");
        public JumpState(PenguinController penguin) : base(penguin) { }

        public override void Start()
        {
            if (penguin.PreviousState != penguin.slideState)
                penguin.animator.SetTrigger(_animParamId);
            penguin.rigidbody.AddForce(Vector2.up * penguin.settings.JumpStrength, ForceMode2D.Impulse);
        }

        public override void Update()
        {
            if (penguin.attackAction.WasPressedThisFrame() && penguin.HasAMeleeWeapon())
                penguin.ChangeState(penguin.meleeAttackState);
        }

        public override void FixedUpdate()
        {
            if (penguin.PreviousState != penguin.slideState)
                penguin.rigidbody.velocity = new Vector2(penguin.settings.smoothInput.x * penguin.settings.Speed, penguin.rigidbody.velocity.y);

            if (!(penguin.rigidbody.velocity.y < 0.1f) || !penguin.Grounded) return;
            
            if (penguin.settings.rawInput.y < -0.5f && Mathf.Abs(penguin.rigidbody.velocity.x) > 1)
                penguin.ChangeState(penguin.slideState);
            else if (penguin.settings.rawInput.x != 0f)
                penguin.ChangeState(penguin.runState);
            else
                penguin.ChangeState(penguin.idleState);
        }

        public override string ToString() => "Jumping";
    }
}
