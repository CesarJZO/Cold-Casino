using UnityEngine;

namespace Bear
{
    public class AttackState : EnemyState<Bear>
    {
        private readonly int _animParamId = Animator.StringToHash("Attack");
        private float timer = 1;
            
        public AttackState(Bear enemy) : base(enemy)
        {
            
        }
    
        public override void Start()
        {
            enemy.animator.SetTrigger(_animParamId);
            Object.Instantiate(enemy.projectile);
        }

        public override void Update()
        {
            timer -= Time.deltaTime;
                
            if(timer < 0)
                enemy.ChangeState(enemy.walkState);
        }
    }
}
