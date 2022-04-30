using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 velocity;
    [SerializeField] private float moveSpeed;
    private bool jump = false;
    [SerializeField] private float jumpForce;

    private void Update()
    {
        GetMovement();
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;

        if (jump)
        {
            rb.velocity = Vector2.up * jumpForce;
            jump = false;
        }
    }

    private void GetMovement()
    {
        velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
    }
}
