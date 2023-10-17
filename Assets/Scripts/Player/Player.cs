using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 8f;
    [SerializeField] public float jumpForce = 12f;

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
}
