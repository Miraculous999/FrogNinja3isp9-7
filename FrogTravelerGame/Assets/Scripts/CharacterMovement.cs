using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // This field is directly edited from unity now
    [SerializeField] private float speed;

    [SerializeField] private float jumpForce;
    private bool jumpControl;
    private int jumpIteration = 0;
    public int jumpValueIteration = 60;

    public LayerMask Ground;
    public bool onGround;
    public Transform groundCheck;
    private float checkRadius;

    // Components 
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        // Initializing of the components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        checkRadius = groundCheck.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Flip character to the needful side 
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Set animator parameters
        animator.SetBool("IsRunning", horizontalInput != 0);

        Jump();
        CheckingGround();
    }

    // Jumping
    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround)
            {
                jumpControl = true;
            }
        }
        else
        {
            jumpControl = false;
        }

        if (jumpControl)
        {
            if (jumpIteration++ < jumpValueIteration)
            {
                //rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
                rb.AddForce(Vector2.up * jumpForce / jumpIteration);
            }
        }
        else
        {
            jumpIteration = 0;
        }
    }

    public void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
        animator.SetBool("OnGround", onGround);
    }
}
