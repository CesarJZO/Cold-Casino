using UnityEngine;

namespace Penguin
{
    public class RunState : PenguinState
    {
        public RunState(PenguinController penguin) : base(penguin) { }

        public override void Update()
        {
            if (penguin.rawInput == Vector2.down) 
                penguin.ChangeState(penguin.slideState);

            else if (penguin.jumpAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.jumpState);
            
            else if (penguin.rawInput.x == 0)
                penguin.ChangeState(penguin.idleState);
        }

        public override void FixedUpdate()
        {
            penguin.rigidbody.velocity = new Vector2(penguin.smoothInput.x, penguin.rigidbody.velocity.y);
        }
    }
}