using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    // Start is called before the first frame update
    public new string name;
    public int price;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool IsPurchased()
    {
        return StoragePrefs.IsItemSold(name);
    }
}
