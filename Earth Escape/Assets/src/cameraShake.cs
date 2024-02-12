using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public float duration = 1f;
    public AnimationCurve curve;
    IEnumerator Shaking()
    {
        Vector3 startpo = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startpo + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startpo;
    }
}
