using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float CameraShakeDuration = 4f;
    public float CameraShakeMagnitude = 1f;

    public IEnumerator Shake()
    {
        Vector3 startingPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < CameraShakeDuration)
        {
            float x = Random.Range(-1f, 1f) * CameraShakeMagnitude;
            float y = Random.Range(-1f, 1f) * CameraShakeMagnitude;

            transform.localPosition = new Vector3(x, y, startingPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = startingPos;
    }
}
