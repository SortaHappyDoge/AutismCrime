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
    

    void Update()
    {
        //transform.position += transform.forward * Time.deltaTime * speed;
        transform.Translate(new Vector3(0,1,0)*speed*Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0) { Destroy(gameObject); }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided" + " "+ collision.transform.name);
        collision.transform.GetComponent<EnemyManager>().GetHit(damage, knockback, stun, transform.position);
        Destroy(gameObject);
    }
}
