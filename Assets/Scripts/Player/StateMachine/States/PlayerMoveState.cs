using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }
}
