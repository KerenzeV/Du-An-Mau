using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    private Rigidbody2D _rigibody2D;
    private Vector2 moveInput;
    private Animator _animator;
    private CapsuleCollider2D _capsuleCollider2D;
    private float gravityScaleAtStart;
    private bool isAlive;

    void Start()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = _rigibody2D.gravityScale;
        isAlive = true;
    }

    void Update()
    {
        if (!isAlive) return;

        Run();
        FlipSprite();
        ClimbLadder();
        CheckForDeath();
    }

    void OnMove(InputValue value)
    {
        if (isAlive) moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (isAlive && value.isPressed && _capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _rigibody2D.velocity += new Vector2(0, jumpSpeed);
        }
    }

    private void Run()
    {
        Vector2 moveVelocity = new Vector2(moveInput.x * moveSpeed, _rigibody2D.velocity.y);
        _rigibody2D.velocity = moveVelocity;
        _animator.SetBool("isRunning", Mathf.Abs(moveInput.x) > Mathf.Epsilon);
    }

    private void FlipSprite()
    {
        if (Mathf.Abs(_rigibody2D.velocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigibody2D.velocity.x), 1f);
        }
    }

    private void ClimbLadder()
    {
        if (!_capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladders")))
        {
            _rigibody2D.gravityScale = gravityScaleAtStart;
            _animator.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(_rigibody2D.velocity.x, moveInput.y * climbSpeed);
        _rigibody2D.velocity = climbVelocity;
        _animator.SetBool("isClimbing", Mathf.Abs(moveInput.y) > Mathf.Epsilon);
        _rigibody2D.gravityScale = 0;
    }

    private void CheckForDeath()
    {
        if (_capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Slime", "Trap")))
        {
            isAlive = false;
            _animator.SetTrigger("Dying");
            _rigibody2D.velocity = Vector2.zero;

            GameController.Instance.ProcessPlayerDeath();
            GameController.Instance.ResetScore();
        }
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) return;

        _animator.SetTrigger("Attack");

        GameObject oneBullet = Instantiate(bullet, gun.position, transform.rotation);
        Rigidbody2D bulletRb = oneBullet.GetComponent<Rigidbody2D>();

        if (transform.localScale.x < 0)
        {
            bulletRb.velocity = new Vector2(-15, 0);
            oneBullet.transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            bulletRb.velocity = new Vector2(15, 0);
        }

        Destroy(oneBullet, 2f);
    }
}
