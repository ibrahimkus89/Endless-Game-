using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 direction;
    [SerializeField] float forwardSpeed;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        direction.z = forwardSpeed;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);

    }
}
