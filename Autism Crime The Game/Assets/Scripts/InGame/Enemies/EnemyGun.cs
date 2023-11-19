using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [Header("GunAttributes")]
    public float rateOfFire;
    float currentCooldown;
    public bool isEnabled;

    [Header("GunReferences")]
    public GameObject projectile;
    public Transform projectileOrigin;
    StaminaBar staminaBar;

    private void Start()
    {
        currentCooldown = rateOfFire;
        staminaBar = GetComponent<StaminaBar>();
    }
    private void FixedUpdate()
    {
        currentCooldown -= Time.fixedDeltaTime;
        staminaBar.StaminaRemap(currentCooldown, 0, rateOfFire);
    }

    public void ClickMessage()
    {
        if (!isEnabled) { return; }
        Shoot();
    }

    public void Shoot()
    {
        if (currentCooldown > 0) { return; }
        Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation);
        currentCooldown = rateOfFire;
    }
}