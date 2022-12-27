using UnityEngine;

namespace Bear
{
    public class WalkState : EnemyState<Bear>
    {
        private readonly int _animParamId = Animator.StringToHash("Walk");
        private float timer = 2;

        public WalkState(Bear enemy) : base(enemy)
        {
        }

        public override void Start()
        {
            enemy.animator.SetTrigger(_animParamId);
        }

        public override void Update()
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                enemy.ChangeState(enemy.attackState);
                return;
            }
        }

        public override void FixedUpdate()
        {

            if(enemy.isGroundedLeft && !enemy.isGroundedRight)
                enemy.direction = Vector2.left;
        }
    }
}