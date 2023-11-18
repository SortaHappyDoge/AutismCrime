using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [Header("PlayerAttributes")]
    public float health;
    public bool isStunned;
    float stunTime;
    float bleedSpeed;
    float totalBleed;

    [Header("PlayerReferences")]
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
            SceneManager.LoadScene("StartMenu");
        }
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
        if (stunTime < stun) { stunTime = stun; } //Stun
    }
}
