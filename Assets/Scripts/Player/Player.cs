using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine
    {
        get => _stateMachine;
    }

    public PlayerIdleState IdleState
    {
        get => _idleState;
    }

    public PlayerMoveState MoveState
    {
        get => _moveState;
    }
    
    private PlayerStateMachine _stateMachine;
    
    private PlayerIdleState _idleState;
    private PlayerMoveState _moveState;

    private void Awake()
    {
        _stateMachine = new PlayerStateMachine();

        _idleState = new PlayerIdleState(this, _stateMachine, "idle");
        _moveState = new PlayerMoveState(this, _stateMachine, "move");
    }

    private void Start()
    {
        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }
}
