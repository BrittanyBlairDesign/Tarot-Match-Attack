using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

     public IEnumerator Shake(float timer, float Magnitude)
    {
        Vector3 startpose = transform.position;

        float elapsed = 0.0f;

        while(elapsed < timer)
        {

            float x = Random.Range(-.5f, .5f) * Magnitude;

            transform.localPosition = new Vector3(x, startpose.y, startpose.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = startpose;
    }
}
