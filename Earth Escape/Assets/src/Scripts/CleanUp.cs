using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // remove 
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
