using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.Rigidbody2D.velocity = new Vector2(Player.Rigidbody2D.velocity.x, Player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        if (Player.Rigidbody2D.velocity.y < 0)
        {
            StateMachine.ChangeState(Player.AirState);
        }
    }
}
