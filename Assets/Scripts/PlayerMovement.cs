using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isMoving;
    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move the player
        Vector3 move = transform.right * x + transform.forward * z;
        // actually moving the player
        controller.Move(move * speed * Time.deltaTime);

        // Check if the player can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Going up
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Falling down
        velocity.y += gravity * Time.deltaTime;

        // Excuting the jump
        controller.Move(velocity * Time.deltaTime);

        if(lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            // for later use
        }
        else
        {
            isMoving = false;
            // for later use
        }
        lastPosition = gameObject.transform.position;
    }
}
