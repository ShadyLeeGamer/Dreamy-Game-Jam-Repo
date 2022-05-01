using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCol;

    private Vector2 velocity;
    [SerializeField] private float moveSpeed;

    private bool onGround = false;
    private bool jump = false;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask platformMask;

    private void Update()
    {
        GetMovement();
        CheckOnGround();
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

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            jump = true;
    }

    private void CheckOnGround()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.BoxCast(origin, boxCol.size, 0f, Vector2.down, 0.05f, platformMask);

        onGround = hit.collider != null;
    }
}
