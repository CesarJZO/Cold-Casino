namespace Penguin
{
    public class MeleeAttackState : PenguinState
    {
        public MeleeAttackState(PenguinController penguin) : base(penguin) { }

        public override void Update()
        {
            penguin.ChangeState(penguin.idleState);
        }

        public override string ToString() => "Attacking";
    }
}