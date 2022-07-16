using Unity.VisualScripting;
using UnityEngine;

namespace Penguin
{
    public class JumpState : PenguinState
    {
        public JumpState(PenguinController penguin) : base(penguin) { }

        public override void Start()
        {
            penguin.rigidbody.AddForce(Vector2.up * penguin.Settings.JumpStrength, ForceMode2D.Impulse);
        }

        public override void FixedUpdate()
        {
            if (penguin.PreviousState != penguin.slideState && !penguin.lockAction.IsPressed())
                penguin.rigidbody.velocity = new Vector2(penguin.smoothInput.x * penguin.Settings.Speed, penguin.rigidbody.velocity.y);
            
            if (!(penguin.rigidbody.velocity.y < 0) || !penguin.Grounded) return;
            
            if (penguin.rawInput.x != 0f)
                penguin.ChangeState(penguin.runState);
            else
                penguin.ChangeState(penguin.idleState);
        }

        public override string ToString() => "Jumping";
    }
}
