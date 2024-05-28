using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float speed;
    Rigidbody2D rb;
    public float jumpSpeed;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckDistance = 0.1f;
    bool isTouchingGround;
    bool isOnLadder; // Biến để xác định xem nhân vật có đang ở trên cầu thang không
    float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckGround();
        Jump();
        ClimbLadder(); 
    }

    void Move()
    {
        // Di chuyển ngang
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // Xoay hình ảnh khi di chuyển sang trái hoặc phải
        if (horizontalInput < 0)
            spriteRenderer.flipX = true;
        else if (horizontalInput > 0)
            spriteRenderer.flipX = false;
    }

    void CheckGround()
    {
        // Raycast xuống dưới để kiểm tra xem nhân vật có đang đứng trên mặt đất hay không
        isTouchingGround = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            isTouchingGround = false;
        }
    }

    void ClimbLadder()
    {
        // Kiểm tra xem nhân vật có đang ở trên cầu thang không
        if (isOnLadder)
        {
            // Lấy input dọc từ trục y (phím lên hoặc xuống)
            verticalInput = Input.GetAxis("Vertical");

            // Di chuyển nhân vật theo trục y dựa trên input dọc
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * speed);

            // Không cho nhân vật nhảy khi đang trên cầu thang
            if (Input.GetKeyDown(KeyCode.Space))
                rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra khi nhân vật va chạm với cầu thang
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = true;
            rb.gravityScale = 0; // Tắt trọng lực để nhân vật không rơi khi trên cầu thang
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Kiểm tra khi nhân vật rời khỏi cầu thang
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = false;
            rb.gravityScale = 1; // Bật lại trọng lực khi nhân vật rời khỏi cầu thang
        }
    }

    void OnDrawGizmosSelected()
    {
        // Vẽ raycast trong editor để kiểm tra
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }
}
