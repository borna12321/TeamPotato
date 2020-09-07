using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
      private Vector3 offSet;
      public Transform target;
    private Vector3 moveVector;
    void Start()
    {
        offSet = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offSet.z+target.position.z);
        transform.position =newPosition;           


    }
}
