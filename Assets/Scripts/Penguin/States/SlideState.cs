namespace Penguin
{
    public class SlideState : PenguinState
    {
        public SlideState(PenguinController penguin) : base(penguin) { }
        
        public override void Update()
        {
            if (!(penguin.rawInput.y >= 0)) return;
            
            if (penguin.jumpAction.WasPressedThisFrame())
                penguin.ChangeState(penguin.jumpState);
            else if (penguin.rawInput.x == 0)
                penguin.ChangeState(penguin.idleState);
            else
                penguin.ChangeState(penguin.runState);
        }
    }
}
