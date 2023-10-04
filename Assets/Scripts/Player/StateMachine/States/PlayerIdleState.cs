using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StateMachine.ChangeState(Player.MoveState);
        }
    }
}
