public class StateMachine
{
    private State _currentState;
    public State CurrentState => _currentState;

    public void Initalize(State state)
    {
        _currentState = state;
        state.Start();
    }

    public void ChangeState(State state)
    {
        _currentState.Stop();
        _currentState = state;
        state.Start();
    }
}