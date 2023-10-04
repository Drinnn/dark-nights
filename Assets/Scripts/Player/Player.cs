using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator Animator
    {
        get => _animator;
    }
    
    private Animator _animator;
    #endregion
    
    #region StateMachine
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
    #endregion

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>(); 
        _stateMachine = new PlayerStateMachine();

        _idleState = new PlayerIdleState(this, _stateMachine, "Idle");
        _moveState = new PlayerMoveState(this, _stateMachine, "Move");
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
