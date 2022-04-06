using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koekie : MonoBehaviour
{
    private const float YMin = -20.0f;
    private const float YMax = 20.0f;

    public Transform lookAt;

    public Transform Player;

    public float distance;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity;

    void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * sensivity;
        currentY += Input.GetAxis("Mouse Y") * sensivity;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;

        transform.LookAt(lookAt.position);
    }
}
