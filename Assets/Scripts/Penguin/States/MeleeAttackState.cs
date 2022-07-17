using UnityEngine;

namespace Penguin
{
    public class MeleeAttackState : PenguinState
    {
        private readonly int _animParamId = Animator.StringToHash("Melee");
        public MeleeAttackState(PenguinController penguin) : base(penguin) { }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Start()
        {
            penguin.animator.SetTrigger(_animParamId);
            
            if (penguin.status.currentWeapon.name.Contains("Axe"))
                penguin.axeHitbox.SetActive(true);
            else
                penguin.katHitbox.SetActive(true);

            penguin.status.currentWeapon.GetComponent<Animator>().SetTrigger(_animParamId);
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
            penguin.rigidbody.velocity = new Vector2(penguin.settings.smoothInput.x * penguin.settings.Speed, penguin.rigidbody.velocity.y);
        }

        public override void Stop()
        {
            penguin.axeHitbox.SetActive(false);
            penguin.katHitbox.SetActive(false);
        }

        public override string ToString() => "Attacking";
    }
}
