using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition = new Vector3(20, 5, 5);
    private float duration = 1f;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void OnEnable()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / duration;

        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
    }
}
