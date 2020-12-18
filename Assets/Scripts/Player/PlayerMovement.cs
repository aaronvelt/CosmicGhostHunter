using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 3f;
    public float sprintSpeed = 10f;
    public float gravity = -9.81f;
    public float velocitySpeed = -2f;
    public float groundDistance = -2f;
    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // player movement control. set speed to sprint sped when shift button is pressed down
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float speed = 0f;

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        controller.Move(move * speed * Time.deltaTime);

        // apply velocity when player is not on ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = velocitySpeed;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

