using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class CameraUpward : MonoBehaviour
{
    //public Transform target;
    public float smoothSpeed = 0.3f;
    public float upwardSpeed = 0.3f;
    public GameObject[] backgrounds;

    private Vector3 currentVelocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // move the camera upward every seconds

        Vector3 targetPosition = new(transform.position.x, transform.position.y + upwardSpeed, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothSpeed);


        //transform.position = targetPosition;


    }
}
