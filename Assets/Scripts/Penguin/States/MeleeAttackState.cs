using UnityEngine;

namespace Penguin
{
    public class MeleeAttackState : PenguinState
    {
        private readonly int _animParamId = Animator.StringToHash("Melee");
        public MeleeAttackState(PenguinController penguin) : base(penguin) { }

        public override void Start()
        {
            penguin.animator.SetTrigger(_animParamId);
        }

        public override void Update()
        {
            if (penguin.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
            
            penguin.ChangeState(penguin.idleState);
        }

        public override string ToString() => "Attacking";
    }
}