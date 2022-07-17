namespace Penguin
{
    public class PenguinState : State
    {
        protected readonly PenguinController penguin;

        protected PenguinState(PenguinController penguin) => this.penguin = penguin;
    }
}
