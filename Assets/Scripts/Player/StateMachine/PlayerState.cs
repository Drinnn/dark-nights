public class PlayerState
{
    protected Player Player;
    protected PlayerStateMachine StateMachine;

    private string _animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        StateMachine = stateMachine;
        Player = player;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        Player.Animator.SetBool(_animBoolName, true);
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        Player.Animator.SetBool(_animBoolName, false);
    }
}
