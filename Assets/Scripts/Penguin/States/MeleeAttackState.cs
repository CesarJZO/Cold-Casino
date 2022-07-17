using UnityEngine;

namespace Penguin
{
    public class MeleeAttackState : PenguinState
    {
        private readonly int _animParamId = Animator.StringToHash("Melee");
        public MeleeAttackState(PenguinController penguin) : base(penguin) { }

        public override void Start()
        {
            penguin.axeHitbox.SetActive(true);
            penguin.animator.SetTrigger(_animParamId);
        }

        public override void Update()
        {
            if (penguin.jumpAction.WasPressedThisFrame() && penguin.Grounded)
                penguin.ChangeState(penguin.jumpState);
            
            if (penguin.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
            
            penguin.ChangeState(penguin.idleState);
        }

        public override void FixedUpdate()
        {
            penguin.rigidbody.velocity = new Vector2(penguin.settings.smoothInput.x * penguin.settings.Speed,
                penguin.rigidbody.velocity.y);
        }

        public override void Stop()
        {
            penguin.axeHitbox.SetActive(false);
        }

        public override string ToString() => "Attacking";
    }
}
