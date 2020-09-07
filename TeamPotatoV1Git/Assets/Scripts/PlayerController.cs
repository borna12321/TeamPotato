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
    public float gravity = 6;
    
    public CameraShake cameraShake;
    
    private int desiredLane =1;
    public float landeDist = 4;
    
    public float t= 0.0f;
    public float jumpForce;
    
    void Start()
    {   
        controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {



        direction.z= forwardSpeed;
        // direction.y+=gravity*Time.deltaTime;
        // direction=Vector3.zero;

            if (controller.isGrounded)
            {
                 if (Input.GetKeyDown(KeyCode.Space))
                    {
                      Jump(); 

                    }
                verticalVelocity=0f;
                //direction.y=verticalVelocity;
                
            }
            else
            {
                
                verticalVelocity-=gravity*Time.deltaTime;
                direction.y=Mathf.Lerp(direction.y,verticalVelocity,6*Time.deltaTime);
            }
     
       
        
        // direction.y=Input.GetAxis("Vertical")*jumpSpeed+verticalVelocity;
       

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane == 3){
                desiredLane = 2; 
            }
        }
         if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane == -1){
                desiredLane = 0;
            }
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane==0)
        {

            targetPosition+= Vector3.Lerp(targetPosition,Vector3.left*landeDist,Mathf.SmoothStep(0.0f,50.0f,50*Time.fixedDeltaTime));

        }else if (desiredLane==2)
        {
            targetPosition +=Vector3.Lerp(targetPosition,Vector3.right*landeDist,Mathf.SmoothStep(0.0f,500.0f,500*Time.fixedDeltaTime));
        }
        
        //transform.position = Vector3.Lerp(transform.position,targetPosition,Mathf.SmoothStep(0.0f,10.0f,10*Time.fixedDeltaTime));
        if (transform.position==targetPosition)
         return;
        Vector3 diff = targetPosition -transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude<diff.magnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);

        
    }


    private void FixedUpdate() {
        controller.Move(direction*Time.fixedDeltaTime);
    }
    private void Jump()
    {
            direction.y=jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.transform.tag=="Obstacle")
        {
            
           // StartCoroutine(cameraShake.Shake(.15f,.4f));
            PlayerManager.gameOver=true;
        }   
    }
}
