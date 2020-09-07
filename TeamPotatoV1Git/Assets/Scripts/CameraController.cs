using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;



    void Start()
    {
       lookAt = GameObject.FindGameObjectWithTag("Player").transform;
       startOffset = transform.position - lookAt.position;
    }

    void Update()
    {
        moveVector=lookAt.position+startOffset; 
        //x
        moveVector.x=0;


        //y
        


        //z





        transform.position = lookAt.position + startOffset;
    }
}
