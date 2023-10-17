public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (Player.Rigidbody2D.velocity.y == 0)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }
}
