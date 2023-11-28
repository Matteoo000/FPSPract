/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed;
    public float runningSpeed;
    public float gravity;
    public float jumpSpeed;

    public CharacterController characterController;

    private float xMove;
    private float zMove;
    private Vector3 move;
    private bool isJumping;
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        gravity = -6; // Set to a negative value for downward gravity
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is running
        isRunning = Input.GetKey(KeyCode.LeftShift);

      
        float currentSpeed = isRunning ? runningSpeed : walkingSpeed;

        xMove = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        zMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * xMove + transform.forward * zMove;

        if (characterController.isGrounded)
        {
            
            move.y = gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                
                move.y  = jumpSpeed;
            }
        }
        else
        {
            // Apply gravity continuously when the character is in the air
            move.y += gravity * Time.deltaTime;
        }

        characterController.Move(move);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed;
    public float runningSpeed;
    public float gravity;
    public float jumpSpeed;

    public CharacterController characterController;

    private float xMove;
    private float zMove;
    private Vector3 move;
    private bool isJumping;
    private float verticalVelocity; // Adjusted for smooth jumping
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        gravity = -9.81f; // Set to a negative value for downward gravity
        verticalVelocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal") * walkingSpeed * Time.deltaTime;
        zMove = Input.GetAxis("Vertical") * walkingSpeed * Time.deltaTime;

        move = transform.right * xMove + transform.forward * zMove;

        // Check if the player is running
        isRunning = Input.GetKey(KeyCode.LeftShift);


        float currentSpeed = isRunning ? runningSpeed : walkingSpeed;

        xMove = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        zMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * xMove + transform.forward * zMove;

        if (characterController.isGrounded)
        {
            // Apply gravity only when the character is grounded
            verticalVelocity = Mathf.MoveTowards(verticalVelocity, gravity, Time.deltaTime * jumpSpeed);

            if (Input.GetButtonDown("Jump"))
            {
                // Jump only if the jump button is pressed and the character is grounded
                verticalVelocity = jumpSpeed;
            }
        }
        else
        {
            // Apply gravity continuously when the character is in the air
            verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = verticalVelocity * Time.deltaTime;

        characterController.Move(move);
    }
}