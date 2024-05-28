using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirection))]
public class Knight : MonoBehaviour
{
    public float _walkSpeed = 50f;

    Rigidbody2D _rb;

    TouchingDirection touchingDirection;

    public enum WalkAbleDirection { Right, Left}

    private WalkAbleDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkAbleDirection walkDirection
    {
        get { return _walkDirection; } 
        set { 
            if (_walkDirection != value)
            {
                // flip direction
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkAbleDirection.Right)
                {
                    walkDirectionVector = Vector2.right;

                }else if (value == WalkAbleDirection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }
            }
            
            
            _walkDirection = value; }
    }

    // Start is called before the first frame update

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        touchingDirection = GetComponent<TouchingDirection>();
    }

    private void FixedUpdate()
    {

        if( touchingDirection.IsGrounded && touchingDirection.IsOnWall )
        {
            FlipDirection();
        }

        _rb.velocity = new Vector2(_walkSpeed = walkDirectionVector.x, _rb.velocity.y);
    }

    private void FlipDirection()
    {
        if(walkDirection == WalkAbleDirection.Right)
        {
            walkDirection = WalkAbleDirection.Left;
        }else if(walkDirection == WalkAbleDirection.Left)
        {
            walkDirection = WalkAbleDirection.Right;
        }
        else
        {
            Debug.Log("Current walkable direction is not set to legal value of right or left");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
