using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonBullet : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject clone = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(clone, 0.06f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject clone = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(clone, 0.06f);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position -= new Vector3(0f, Time.deltaTime * 3, 0f);
    }
}
