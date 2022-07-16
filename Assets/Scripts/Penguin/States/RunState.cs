using UnityEngine;

namespace Penguin
{
    public class RunState : PenguinState
    {
        public RunState(PenguinController penguin) : base(penguin) { }

        public override void Update()
        {
            if (penguin.rawInput.x == 0 || penguin.lockAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.idleState);
    
            else if (penguin.rawInput.y < -0.5f && Mathf.Abs(penguin.rigidbody.velocity.x) > penguin.settings.Speed / 2)
                penguin.ChangeState(penguin.slideState);
    
            else if (penguin.jumpAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.jumpState);
        }

        public override void FixedUpdate()
        {
            penguin.rigidbody.velocity = new Vector2(penguin.smoothInput.x * penguin.settings.Speed, penguin.rigidbody.velocity.y);
        }

        public override string ToString() => "Running";
    }
}
