using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Attributes")]
    public float health;
    float bleedSpeed;
    float totalBleed;

    [Header("Enemy References")]
    ItemManager itemManager;



    private void Start()
    {
        if (transform.GetComponent<ItemManager>()) { itemManager = transform.GetComponent<ItemManager>(); }
    }

    public void GetMeleed(Vector2 attackPosition, float damage, float stun, float knockback, float bleed)
    {
        CalculateKnockback(attackPosition, knockback);
        totalBleed = bleed;

    }

    public void CalculateDamage()
    {
        
    }

    public void CalculateKnockback(Vector2 attackPosition, float knockback)
    {
        Vector2 difference = new Vector2(attackPosition.x - transform.position.x, attackPosition.y - transform.position.y).normalized * -knockback;
        Vector3 knockbackCalculation = new Vector3(transform.position.x + difference.x, transform.position.y + difference.y, transform.position.z);
        transform.position = knockbackCalculation;
    }

    //Kullanılmıyo/Çalışmıyo

    /*private IEnumerator ApplyKnockback(Vector3 knockbackCalculation, float knockbackTime)
    {
        float timeLeft = 0.01f;
        while (timeLeft<knockbackTime)
        {
            Debug.Log(timeLeft/knockbackTime);
            transform.position = Vector3.Lerp(knockbackCalculation, transform.position, 0.99f);
            timeLeft += Time.deltaTime;
            yield return null;
        }
    }*/
}
