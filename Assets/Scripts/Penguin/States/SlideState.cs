using UnityEngine;

namespace Penguin
{
    public class SlideState : PenguinState
    {
        private bool _cooldown;
        private float _timer;
        public SlideState(PenguinController penguin) : base(penguin) { }

        public override void Start()
        {
            _cooldown = false;
        }

        public override void Update()
        {
            if (penguin.jumpAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.jumpState);
            
            if (penguin.rawInput.y >= 0 && !_cooldown)
            {
                _cooldown = true;
                _timer = penguin.slideTimer;
                penguin.rigidbody.drag = penguin.drag;
            }

            _timer -= Time.deltaTime;
            
            if (_timer >= 0) return;
            
            if (_cooldown || Mathf.Abs(penguin.rigidbody.velocity.x) < 1)
                penguin.ChangeState(penguin.idleState);
        }

        public override void Stop()
        {
            penguin.rigidbody.drag = 0;
        }

        public override string ToString() => "Sliding";
    }
}
