using UnityEngine;

namespace Penguin
{
    public class JumpState : PenguinState
    {
        public JumpState(PenguinController penguin) : base(penguin) { }

        public override void FixedUpdate()
        {
            penguin.rigidbody.velocity = new Vector2(penguin.smoothInput.x, penguin.rigidbody.velocity.y);
            
            if (!(penguin.rigidbody.velocity.y < 0) || !penguin.Grounded) return;
            
            if (penguin.rawInput.x != 0f)
                penguin.ChangeState(penguin.runState);
            else
                penguin.ChangeState(penguin.idleState);
        }
    }
}
