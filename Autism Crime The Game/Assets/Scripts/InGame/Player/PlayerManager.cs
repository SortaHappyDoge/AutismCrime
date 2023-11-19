using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [Header("PlayerAttributes")]
    public float health;
    public bool isStunned;
    public float knockSpeed;
    float stunTime;
    float bleedSpeed;
    float totalBleed;
    bool gettingKnocked;
    float knockTimer;
    Vector3 knockPos;

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
        if (gettingKnocked)
        {
            transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, knockPos.x, knockSpeed * Time.deltaTime),
            Mathf.Lerp(transform.position.y, knockPos.y, knockSpeed * Time.deltaTime),
            transform.position.z
            );

            knockTimer -= Time.deltaTime;
            if (knockTimer <= 0) { gettingKnocked = false; }
        }
    }

    public void GetMeleed(Vector2 attackPosition, float damage, float stun, float knockback, float bleed)
    {
        
        totalBleed = bleed; //Bleed ekleme
        health -= damage; //Hasar verme
        if (health <= 0)
        {
            SceneManager.LoadScene("StartMenu");
        }
        CalculateKnockback(attackPosition, knockback); //Knockback hesaplama ve uygulama
        if (stunTime < stun) { stunTime = stun; } //Stun
    }

    public void CalculateKnockback(Vector2 attackPosition, float knockback)
    {
        Vector2 difference = new Vector2(attackPosition.x - transform.position.x, attackPosition.y - transform.position.y).normalized * -knockback;
        Vector3 knockbackCalculation = new Vector3(transform.position.x + difference.x, transform.position.y + difference.y, transform.position.z);
        knockPos = knockbackCalculation;
        gettingKnocked = true;
        knockTimer = 0.1f;
        if (stunTime < knockTimer) { stunTime = knockTimer; }
        isStunned = true;
    }

    public void GetHit(float damage, float knockback, float stun, Vector3 attackPosition)
    {    
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene("StartMenu");
        }
        CalculateKnockback(attackPosition, knockback);
        if (stunTime < stun) { stunTime = stun; } //Stun
    }
}
