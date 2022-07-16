public class PenguinState : State
{
    protected PenguinController penguin;
    protected PenguinState(PenguinController penguin) => this.penguin = penguin;
}