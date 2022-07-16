namespace Penguin
{
    public class MeleeAttackState : PenguinState
    {
        public MeleeAttackState(PenguinController penguin) : base(penguin) { }

        public override string ToString() => "Attacking";
    }
}