using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    private Rigidbody2D _rigibody2D;



    // Start is called before the first frame update
    void Start()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigibody2D.velocity = new Vector2(x: moveSpeed, y: 0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed *= -1;
        //Flip
        transform.localScale = new Vector2(x: (-Mathf.Sign(_rigibody2D.velocity.x)), y: 1f);
    }
}
