using System.Collections;
using System.Collections.Generic;
using System.Collections;
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

    public Animator animator;
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundcheck;
    [SerializeField] private float maxSpeed;
    private bool isSliding = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }
        // Increase speed
        if (forwardSpeed < maxSpeed)
        {
          forwardSpeed += 0.1f * Time.deltaTime;

        }

        animator.SetBool("isGameStarted",true);
        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundcheck.position,0.15f,groundLayer);
        animator.SetBool("isGrounded",isGrounded);
        if (controller.isGrounded)
        {
            //direction.y = -1;
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;

        }


        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }
        if (SwipeManager.swipeRight)
        {
            desiredLane++;

            if (desiredLane ==3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
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

        //transform.position = Vector3.Lerp(transform.position,targetPosition,80 * Time.fixedDeltaTime);

        if (transform.position ==targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir =diff.normalized *25 *Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(diff);
        }
        else
        {
            controller.Move(moveDir);
        }
       
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }
        controller.Move(direction * Time.fixedDeltaTime);

    }

    void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Obstacle"))
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding",true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

         yield return new  WaitForSeconds(1.3f);

         controller.center = new Vector3(0, 0, 0);
         controller.height = 2;
         animator.SetBool("isSliding",false);
         isSliding=false;
    }
}
