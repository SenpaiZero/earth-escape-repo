using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.3f;
    private Vector3 currentVelocity;

    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if(target.name == "hot air balloon")
        {
            target = target.GetComponentInChildren<Transform>();
        }
    }

    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            //Vector3 newPos = new(transform.position.x, target.position.y, transform.position.z);
            // smooth damp
            //transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed);

            Vector3 newPos = new (transform.position.x, target.position.y, transform.position.z);
            transform.position = newPos;


        }
    }
}
