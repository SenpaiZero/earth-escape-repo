using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

    public Vector3 Offset = new Vector3(-0.1f, -0.1f);
    public Material Material;
    GameObject _shadow;
    // Start is called before the first frame update
    void Start()
    {
        _shadow = new GameObject("Shadow");
        _shadow.transform.parent = transform;

        _shadow.transform.localPosition = Offset;
        _shadow.transform.localRotation = Quaternion.identity;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer shadowRenderer = _shadow.AddComponent<SpriteRenderer>();

        shadowRenderer.sprite = renderer.sprite;
        shadowRenderer.material = Material;

        shadowRenderer.sortingLayerName = renderer.sortingLayerName;
        shadowRenderer.sortingOrder = renderer.sortingOrder - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
