using UnityEngine;

namespace Penguin
{
    public class SlideState : PenguinState
    {
        private readonly int _animParamId = Animator.StringToHash("Slide");
        private bool _cooldown;
        private float _timer;
        public SlideState(PenguinController penguin) : base(penguin) { }

        public override void Start()
        {
            _cooldown = false;
            penguin.headCollider.enabled = false;
            if (penguin.PreviousState != penguin.jumpState)
                penguin.rigidbody.AddForce(penguin.transform.right * penguin.settings.SlideForce);
            penguin.animator.SetTrigger(_animParamId);
        }

        public override void Update()
        {
            if (penguin.Ceiling) return;

            if (penguin.settings.rawInput.y >= 0 && !_cooldown)
            {
                _cooldown = true;
                _timer = penguin.slideTimer;
                penguin.rigidbody.drag = penguin.drag;
            }

            if (penguin.jumpAction.WasPressedThisFrame())
            {
                penguin.ChangeState(penguin.jumpState);
                return;
            }

            _timer -= Time.deltaTime;
            
            if (_timer >= 0) return;
            
            penguin.rigidbody.drag = 0;
            
            if (_cooldown || Mathf.Abs(penguin.rigidbody.velocity.x) < 0.5f)
                penguin.ChangeState(penguin.idleState);
        }

        public override void FixedUpdate()
        {
            if (penguin.Ceiling && Mathf.Abs(penguin.rigidbody.velocity.x) < 0.5f)
            {
                _cooldown = false;
                penguin.rigidbody.drag = 0;
                penguin.rigidbody.AddForce(penguin.transform.right * penguin.settings.SlideEscape);
            }
        }

        public override void Stop()
        {
            penguin.rigidbody.drag = 0;
            penguin.headCollider.enabled = true;
        }

        public override string ToString() => "Sliding";
    }
}
