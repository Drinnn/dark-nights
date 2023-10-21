using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    [SerializeField] public float moveSpeed = 8f;
    [SerializeField] public float jumpForce = 12f;

    [Header("Collision Info")] 
    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundedCheckDistance;
    [SerializeField] private LayerMask wallCheckLayerMask;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;

    #region Components
    public Animator Animator
    {
        get => _animator;
    }
    public Rigidbody2D Rigidbody2D
    {
        get => _rigidbody2D;
    }
    
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
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

    public PlayerJumpState JumpState
    {
        get => _jumpState;
    }

    public PlayerAirState AirState
    {
        get => _airState;
    }
    
    private PlayerStateMachine _stateMachine;
    private PlayerIdleState _idleState;
    private PlayerMoveState _moveState;
    private PlayerJumpState _jumpState;
    private PlayerAirState _airState;
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundedCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _stateMachine = new PlayerStateMachine();

        _idleState = new PlayerIdleState(this, _stateMachine, "Idle");
        _moveState = new PlayerMoveState(this, _stateMachine, "Move");
        _jumpState = new PlayerJumpState(this, _stateMachine, "Jump");
        _airState  = new PlayerAirState(this, _stateMachine, "Jump");
    }

    private void Start()
    {
        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        _rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
    }

    public bool IsGroundDetected() =>
        Physics2D.Raycast(groundCheck.position, Vector2.down, groundedCheckDistance, groundCheckLayerMask);
}
