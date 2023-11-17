using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlaceholder : MonoBehaviour
{
    [Header("GunAttributes")]
    public float rateOfFire;
    float currentCooldown;
    public bool isEnabled;

    [Header("GunReferences")]
    public GameObject projectile;
    public Transform projectileOrigin;

    private void Update()
    {
        currentCooldown -= Time.deltaTime;
    }

    public void ClickMessage()
    {
        if (!isEnabled) { return; }
        Shoot();
    }

    public void Shoot()
    {
        if(currentCooldown>0) { return; }
        Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation);
        currentCooldown = rateOfFire;
    }
}
