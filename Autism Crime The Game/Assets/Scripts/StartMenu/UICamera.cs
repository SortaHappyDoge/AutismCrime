using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    [Header("CameraAttributes")]
    public float speed;
    public float offset;
    private Vector3 positionOffset;
    private float angle;

    [Header("CameraReferences")]
    public Transform origin;

    

    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos(angle) * offset,
            Mathf.Sin(angle) * offset,
            0
        );
        transform.position = origin.position + positionOffset;
        angle += Time.deltaTime * speed;
    }
}
