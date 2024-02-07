using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitilalizeScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string EquipItem()
    {
        return StoragePrefs.GetEquipItem();
    }
}
