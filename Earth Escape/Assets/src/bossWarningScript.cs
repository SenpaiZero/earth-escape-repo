using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossWarningScript : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(obj, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
