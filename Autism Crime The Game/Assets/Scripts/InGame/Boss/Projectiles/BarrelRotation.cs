using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotation : MonoBehaviour
{
    public Transform gun;

    private void FixedUpdate()
    {
        transform.rotation = gun.rotation;
    }
}
