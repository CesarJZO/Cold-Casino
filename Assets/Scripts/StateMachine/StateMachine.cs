public class StateMachine
{
    public State PreviousState { get; private set; }

    public State CurrentState { get; private set; }

    public void Initialize(State state)
    {
        CurrentState = state;
        state.Start();
    }

    public void ChangeState(State state)
    {
        CurrentState.Stop();
        PreviousState = CurrentState;
        CurrentState = state;
        state.Start();
    }
}