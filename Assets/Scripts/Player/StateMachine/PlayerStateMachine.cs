public class PlayerStateMachine
{
    public PlayerState CurrentState
    {
        get => _currentState;
    }

    private PlayerState _currentState;

    public void Initialize(PlayerState startState)
    {
        _currentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
