using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunBulletScript : MonoBehaviour
{
    public GameObject explosion;

    private void Update()
    {
        transform.position -= new Vector3(0f, Time.deltaTime * 4, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boss")) return;
        if (!collision.gameObject.CompareTag("Player"))
            collision.gameObject.SetActive(false);

        GameObject clone = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(clone, 1.5f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraShake>().StartCoroutine("Shaking");
    }
}
