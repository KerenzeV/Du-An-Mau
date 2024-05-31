using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;
    [SerializeField] float jumpspeed = 5f;
    [SerializeField] float climbspeed = 5f;
    Rigidbody2D _rigidbody2d;
    Vector2 MoveInput;
    Animator _animator;
    CapsuleCollider2D _capsuleCollider;
    private float GravityScaleAtStart;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        GravityScaleAtStart = _rigidbody2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>();
        Debug.Log("Move input"+MoveInput);
    }

    void OnJump(InputValue value)
    {
        var istouchingGround = _capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!istouchingGround) return;
        if(value.isPressed)
        {
            Debug.Log("Jump");
            _rigidbody2d.velocity += new Vector2(0, jumpspeed);
        }
    }

    void Run()
    {
        Vector2 moveVelocity = new Vector2(MoveInput.x * movespeed, _rigidbody2d.velocity.y);
        _rigidbody2d.velocity = moveVelocity;

        bool playerhasHorizontalSpeed = Mathf.Abs(MoveInput.x) > Mathf.Epsilon;
        _animator.SetBool("IsRunning",playerhasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerhasHorizontalSpeed = Mathf.Abs(_rigidbody2d.velocity.x) > Mathf.Epsilon;
        if(playerhasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2d.velocity.x)*4,4f);
        }
    }

    void ClimbLadder()
    {
        var istouchingLadder = _capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"));
        if (!istouchingLadder)
        {
            _rigidbody2d.gravityScale = GravityScaleAtStart;
            _animator.SetBool("IsClimbing", false); 
            return;
        }
        
        var climbVelocity = new Vector2(_rigidbody2d.velocity.x,MoveInput.y * climbspeed);
        _rigidbody2d.velocity = climbVelocity;

        // dieu khien anim leo thang
        var playerhasVeritcalSpeed = Mathf.Abs(MoveInput.y) > Mathf.Epsilon;
        _animator.SetBool("IsClimbing",playerhasVeritcalSpeed);

        _rigidbody2d.gravityScale = 0;
    }
}
