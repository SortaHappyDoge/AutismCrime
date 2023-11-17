using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlaceholder : MonoBehaviour
{
    [Header("ProjectileAttributes")]
    public float damage;
    public float speed;
    public float lifeTime;
    public float stun;
    public float knockback;

    //[Header("GunReferences")]
    

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0,1,0)*speed*Time.fixedDeltaTime);
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime < 0) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<EnemyManager>().GetHit(damage, knockback, stun, transform.position);
        Destroy(gameObject);
    }
}
