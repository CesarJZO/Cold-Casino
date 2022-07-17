using UnityEngine;

namespace Penguin
{
    public class IdleState : PenguinState
    {
        private readonly int _animParamId = Animator.StringToHash("Idle");
        public IdleState(PenguinController penguin) : base(penguin) { }

        public override void Start()
        {
            penguin.animator.SetTrigger(_animParamId);
            penguin.rigidbody.velocity = new Vector2(0, penguin.rigidbody.velocity.y);
        }

        public override void Update()
        {
            if (penguin.lockAction.IsPressed()) return;
            
            if (penguin.settings.rawInput.x != 0f)
                penguin.ChangeState(penguin.runState);
            
            else if (penguin.jumpAction.WasPressedThisFrame() && penguin.Grounded)
                penguin.ChangeState(penguin.jumpState);
            
            else if (penguin.attackAction.WasPressedThisFrame() && penguin.HasAMeleeWeapon())
                penguin.ChangeState(penguin.meleeAttackState);
        }

        public override string ToString() => "Idling";
    }
}
