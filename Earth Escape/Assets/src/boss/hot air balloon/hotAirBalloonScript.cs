using System.Collections;
using UnityEngine;

public class hotAirBalloonScript : MonoBehaviour
{
    private Camera cam;
    private float moveTimer = 0f;
    public float moveInterval = 1f; // Adjust this value to control the interval of movement
    public float moveSpeed = 1f; // Adjust this value to control the movement speed

    private Vector3 targetPosition;
    public Transform warningPos;
    public GameObject warning, bullet;
    bool isMove;
    void Start()
    {
        isMove = false;
        cam = Camera.main;
        SetRandomXPosition();
    }

    void LateUpdate()
    {
        gameObject.transform.position = new Vector3(transform.position.x, cam.transform.position.y + 3, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

        float clampedX = Mathf.Clamp(transform.position.x, -cam.orthographicSize * cam.aspect, cam.orthographicSize * cam.aspect);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    IEnumerator SetRandomXPosition()
    {
        isMove = true;
        float randomX = Random.Range(-4f, 4f); 
        targetPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(3);
        //Attack first
        GameObject cloneWarn = Instantiate(warning, warningPos.position, Quaternion.identity);
        cloneWarn.transform.SetParent(warningPos);
        yield return new WaitForSeconds(2);
        Destroy(cloneWarn);
        GameObject bulletClone = Instantiate(bullet, warningPos.position, Quaternion.identity);
        Destroy(bulletClone, 20f);
        //then continue
        isMove = false;
    }

    void Update()
    {
        if(!isMove)
        {
            StartCoroutine(SetRandomXPosition());
        }
    }
}