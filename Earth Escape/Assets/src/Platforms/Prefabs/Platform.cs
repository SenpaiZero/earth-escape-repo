using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Platform : MonoBehaviour
{

    public float jumpForce = 7f;
    public GameObject mainCamera;
    public bool isMovable;
    public float speed = 2f;
    public Transform[] points;
    private int i = 0;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindWithTag("MainCamera");
        }

        if (isMovable)
        {
            points[0].position = new(-LevelGenerator.levelWidth, transform.position.y);
            points[1].position = new(LevelGenerator.levelWidth, transform.position.y);

            transform.position = points[1].position;
        }

        if (InitilalizeScript.EquipItem() == "JumpingBoots")
        {
            // + 20% jump force
            jumpForce = jumpForce * 1.2f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }


    private void Update()
    {

        if (isMovable)
        {

            // check if the transform position is equal to the points position
            if (transform.position.x == points[i].position.x)
            {
                i++;
                if (i >= points.Length)
                {
                    i = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, new(points[i].position.x, transform.position.y), speed * Time.deltaTime);
        }


    }

    private void OnBecameInvisible()
    {
        
    }

}
