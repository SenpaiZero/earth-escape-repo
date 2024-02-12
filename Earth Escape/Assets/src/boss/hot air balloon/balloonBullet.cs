using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonBullet : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boss")) return;

        GameObject clone = Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraShake>().StartCoroutine("Shaking");
        Destroy(clone, 1.5f);
        if (gameObject != null)
            gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position -= new Vector3(0f, Time.deltaTime * 3, 0f);
    }
    private void Start()
    {
        Destroy(gameObject, 5f);   
    }
}
