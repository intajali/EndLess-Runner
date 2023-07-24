using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;

    private CharacterController characterController;
    private float gravity = -50f;
    private Vector3 velocity;

    public bool isGrounded;
    private float horizontalInput;




    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = GetInput();

        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        //check if the player is grounded;
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
            Debug.Log("Player is Grounded");
        }
        else
        {

            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(new Vector3(horizontalInput, 0, 0) * runSpeed * Time.deltaTime);


        // Jump 
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y += Mathf.Sqrt(-jumpHeight * gravity);
        }

        // adding gravity
        characterController.Move(velocity * Time.deltaTime);
    }


    private int GetInput()
    {

        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        if (left)
            return -1;
        if(right)
            return 1;

        return 0;
    }
}
