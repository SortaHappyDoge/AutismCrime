using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("EnemyAttributes")]
    public float health;
    public bool isStunned;
    [Range(1f, 100)]
    public int minimumAmmoDrop; //maximumAmmoDrop ile eşit veya daha küçük olmalı
    [Range(1f, 100)]
    public int maximumAmmoDrop; //minimumAmmoDrop ile eşit veya daha büyük olmalı
    [Range(0f, 100f)]
    public int ammoDropPercentage;
    float stunTime;
    float bleedSpeed;
    float totalBleed;

    [Header("EnemyReferences")]
    public Transform player;
    public GameObject ammoPrefab;
    ItemManager itemManager;

    private void Start()
    {
        if (transform.GetComponent<ItemManager>()) { itemManager = transform.GetComponent<ItemManager>(); }
    }
    private void Update()
    {
        if (totalBleed > 0) { health -= bleedSpeed; totalBleed -= bleedSpeed; }
        if (stunTime > 0) { isStunned = true; } else { isStunned = false; }
        if (health <= 0) 
        { 
            if(Random.Range(0, 100) <= ammoDropPercentage)
            {
                for (int i = Random.Range(minimumAmmoDrop, maximumAmmoDrop); i>0; i--)
                {
                    GameObject ammo = Instantiate(ammoPrefab, transform.position, transform.rotation);
                    ammo.transform.SetParent(null, true);
                }
            }
            Destroy(transform.parent.gameObject);
        }

        //Düşmanı Karaktere Çevir
        transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(player.position.x - transform.position.x, player.position.y - transform.position.y, player.position.z - transform.position.z).normalized);
        transform.rotation.eulerAngles.Set(0, 0, transform.rotation.eulerAngles.z);
        //
    }

    public void GetMeleed(Vector2 attackPosition, float damage, float stun, float knockback, float bleed)
    {
        CalculateKnockback(attackPosition, knockback); //Knockback hesaplama ve uygulama
        totalBleed = bleed; //Bleed ekleme
        health -= damage; //Hasar verme
        if (stunTime < stun) { stunTime = stun; } //Stun
    }

    public void CalculateKnockback(Vector2 attackPosition, float knockback)
    {
        Vector2 difference = new Vector2(attackPosition.x - transform.position.x, attackPosition.y - transform.position.y).normalized * -knockback;
        Vector3 knockbackCalculation = new Vector3(transform.position.x + difference.x, transform.position.y + difference.y, transform.position.z);
        transform.position = knockbackCalculation;
    }

    public void GetHit(float damage, float knockback, float stun, Vector3 attackPosition)
    {
        CalculateKnockback(attackPosition, knockback);
        health -= damage;
        if(stunTime < stun) { stunTime = stun; }
    }
}
