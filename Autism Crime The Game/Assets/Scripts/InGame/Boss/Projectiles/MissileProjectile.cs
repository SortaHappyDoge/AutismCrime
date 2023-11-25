using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileProjectile : MonoBehaviour
{
    [Header("ProjectileAttributes")]
    public float damage;
    public float speed;
    public float lifeTime;
    public float stun;
    public float knockback;
    public float explosionRange;

    [Header("ProjectileReferences")]
    public Transform player;
    public GameObject explosion;


    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime);
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime < 0) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Instantiate(explosion, transform.position, Quaternion.identity);
            if ((transform.position - player.position).magnitude < explosionRange) { player.transform.GetComponent<PlayerManager>().GetHit(damage, knockback, stun, transform.position); }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Enemy") { return; }
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log((transform.position - player.position).magnitude);
        if((transform.position-player.position).magnitude < explosionRange) { player.transform.GetComponent<PlayerManager>().GetHit(damage, knockback, stun, transform.position); }
        
        Destroy(gameObject);
    }
}
