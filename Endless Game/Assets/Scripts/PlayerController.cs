using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 direction;
    [SerializeField] float forwardSpeed;
    int desiredLane = 1;
    [SerializeField] float laneDistance = 4;
    [SerializeField] float jumpForce;
    [SerializeField] float Gravity = -20;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        direction.z = forwardSpeed;


        if (controller.isGrounded)
        {
            //direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;

            if (desiredLane ==3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;

            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane ==0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane ==2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition,80 * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);

    }

    void Jump()
    {
        direction.y = jumpForce;
    }
}
