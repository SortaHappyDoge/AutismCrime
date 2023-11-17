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
    ItemManager itemManager;

    private void Start()
    {
        itemManager = GetComponentInParent<ItemManager>();
    }
    /*private void Update()
    {
        currentCooldown -= Time.deltaTime;
    }*/
    private void FixedUpdate()
    {
        currentCooldown -= Time.fixedDeltaTime;
    }

    public void ClickMessage()
    {
        if (!isEnabled) { return; }
        Shoot();
    }

    public void Shoot()
    {
        if(currentCooldown>0 || itemManager.ammo <= 0) { return; }
        Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation);
        itemManager.ammo -= 1;
        currentCooldown = rateOfFire;
    }
}
