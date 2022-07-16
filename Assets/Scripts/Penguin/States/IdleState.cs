using UnityEngine;

namespace Penguin
{
    public class IdleState : PenguinState
    {
        public IdleState(PenguinController penguin) : base(penguin) { }

        public override void Update()
        {
            if (penguin.rawInput.x != 0f)
                penguin.ChangeState(penguin.runState);
            
            else if (penguin.jumpAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.jumpState);
            
            else if (penguin.attackAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.meleeAttackState);
        }
    }
}
