using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    Animator anim;
   

   
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        // if the collision is player and it at the top of the trampoline
        // detecting the velocity negative means the player is falling down
        if (collision.gameObject.CompareTag("Player")  && collision.relativeVelocity.y <= 0)
        {

             anim.SetTrigger("TriggerBounce");
             collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500f);

        }

  
      

    }
    
    
}
