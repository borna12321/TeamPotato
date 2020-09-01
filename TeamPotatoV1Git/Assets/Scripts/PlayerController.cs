using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    //private Vector3 moveVector;
    public float forwardSpeed = 5f; 
    public float verticalVelocity = 0.0f;
    public float gravity = 9;
    
    void Start()
    {   
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        direction=Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity=-0.5f;
        }
        else
        {
            verticalVelocity-=gravity*Time.deltaTime;
        }

        direction.x = Input.GetAxis("Horizontal")*forwardSpeed;

        direction.y=verticalVelocity;
        
        direction.z= forwardSpeed;







        
        controller.Move(direction*Time.deltaTime);
    }



}
