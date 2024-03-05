using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sunBossScript : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] GameObject bullet, warning;
    private Camera cam;
    private bool isMove = false;
    void Start()
    {
        cam = Camera.main;
        isMove = false;
    }

    private void Update()
    {
        if(isMove == false)
            StartCoroutine(attack());
    }
    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = new Vector3(0, cam.transform.position.y + 3, 1);
        
    }

    IEnumerator attack()
    {
        isMove = true;
        int rand = Random.Range(0, positions.Length);
        GameObject warnClone = Instantiate(warning, new Vector2(positions[rand].position.x, positions[rand].position.y + 2), Quaternion.identity);
        warnClone.transform.SetParent(positions[rand]);
        yield return new WaitForSeconds(5);
        Destroy(warnClone);
        GameObject bulClone = Instantiate(bullet, positions[rand].position, Quaternion.identity);
        Destroy(bulClone, 5f);
        isMove = false;
    }

}
