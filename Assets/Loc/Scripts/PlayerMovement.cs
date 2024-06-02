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
    Vector2 moveInput;
    private Animator _animator;
    CapsuleCollider2D _capsuleCollider2D;
    private float gravityScaleAtStart;

    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = _rigibody2D.gravityScale;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Climbladder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(message: ">>>>>> Move Input: " + moveInput);
    }

    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        //Kiem tra nhay 2 lan
        var isTouchingGround = _capsuleCollider2D
            .IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!isTouchingGround) return;

        //Neu nguoi choi nhan nut nhay
        if (value.isPressed)
        {
            Debug.Log(message: ">>>>> Jump");
            _rigibody2D.velocity += new Vector2(x: 0, y: jumpSpeed);
        }
    }

    // Dieu khien chuyen dong nhan vat
    private void Run()
    {
        var moveVelocity = new Vector2(moveInput.x * moveSpeed, _rigibody2D.velocity.y);
        _rigibody2D.velocity = moveVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        _animator.SetBool(name: "isRunning", playerHasHorizontalSpeed);
    }


    // Flip
    // Abs: gia tri tuyet doi
    // Sign: Dau co gia tri
    // Epsilon: gia tri nho nhat co the so sanh
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigibody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(x: Mathf.Sign(_rigibody2D.velocity.x), y: 1f);
        }
    }

    // Climb
    void Climbladder()
    {
        var isTouchingLadder = _capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladders"));
        if (!isTouchingLadder)
        {
            _rigibody2D.gravityScale = gravityScaleAtStart;
            _animator.SetBool("isClimbing", false);
            return;
        }

        var climbVelocity = new Vector2(_rigibody2D.velocity.x, y: moveInput.y * climbSpeed);
        _rigibody2D.velocity = climbVelocity;

        // Animation leo thang
        var playerHasVerticalSpeed = Mathf.Abs(moveInput.y) > Mathf.Epsilon;
        _animator.SetBool("isClimbing", playerHasVerticalSpeed);

        //Gravity off Climb
        _rigibody2D.gravityScale = 0;
    }

    void Die()
    {
        var isTouchingEnemy = _capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Slime", "Trap"));
        if (isTouchingEnemy)
        {
            isAlive = false;
            _animator.SetTrigger("Dying");
            _rigibody2D.velocity = new Vector2(0, 0);

            // xu li die
            FindObjectOfType<GameController>().ProcessPlayerDeath();
        }
    }

    void OnFire(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        Debug.Log(">>>>> Fire");

        // Ani Shoot
        _animator.SetTrigger("Attack");

        // Create bullet 
        var oneBullet = Instantiate(bullet, gun.position, transform.rotation);

        // Flip
        if (transform.localScale.x < 0)
        {
            oneBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
        }
        else
        {
            oneBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
        }

        // Destroy bullet after 2s
        Destroy(oneBullet, 2);


    }
}

