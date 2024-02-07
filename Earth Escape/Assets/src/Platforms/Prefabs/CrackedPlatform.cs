using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedPlatform : MonoBehaviour
{
    Animator anim;
    private bool isCracked = false;
    public float activeSecs = 0.5f;
    // Start is called before the first frame update
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
        if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.y <= 0)
           {
            if (!isCracked)
            { 
                isCracked = true;
                anim.Play("Cracked");
                StartCoroutine(ActiveRoutine());
            }
            }
        
    }


   IEnumerator ActiveRoutine()
   {
      yield return new WaitForSeconds(activeSecs);
      gameObject.SetActive(false);
      isCracked = false;
      yield return new WaitForSeconds(5);
      gameObject.SetActive(true);
    }

 
}
