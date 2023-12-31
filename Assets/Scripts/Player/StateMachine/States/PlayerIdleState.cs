public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        
    }

    public override void Update()
    {
        base.Update();

        if (XInput != 0)
        {
            StateMachine.ChangeState(Player.MoveState);
        }
    }
}
