using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
       _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(moveSpeed, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed *= -1;
        // xoay huong
        transform.localScale = new Vector2(-Mathf.Sign(_rigidbody2D.velocity.x)*4,4f);
    }





}
