using UnityEngine;

public class PlayerState
{
    protected Player Player;
    protected PlayerStateMachine StateMachine;

    private string _animBoolName;

    protected float XInput;

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
        XInput = Input.GetAxisRaw("Horizontal");
        
        Player.Animator.SetFloat("YVelocity", Player.Rigidbody2D.velocity.y);
    }

    public virtual void Exit()
    {
        Player.Animator.SetBool(_animBoolName, false);
    }
}
