using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePlaceholder : MonoBehaviour
{
    [Header("MeleeAttributes")]
    public float damage;
    public float attackSpeed;
    public float stun;
    public float knockback;
    public float bleed;
    float currentFatigue;

    [Header("MeleeReferences")]
    public Collider2D attackCollider;
    public List<Collider2D> enemiesInRange = new List<Collider2D>();

    private void Start()
    {
        attackCollider = transform.GetComponent<Collider2D>();
    }
    private void Update()
    {
        currentFatigue -= Time.deltaTime;
    }

    public void ClickMessage()
    {
        SwingMelee();
    }

    public void SwingMelee()
    {
        if(currentFatigue > 0) { return; }
        foreach(Collider2D enemy in enemiesInRange)
        {
            enemy.transform.GetComponent<EnemyManager>().GetMeleed(transform.position, damage, stun, knockback, bleed);
        }

        currentFatigue = attackSpeed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enemiesInRange.Contains(other)) { enemiesInRange.Add(other); } //Düşman rangeimize girerse listeye ekle
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemiesInRange.Contains(other)) { enemiesInRange.Remove(other); } //Düşman rangeimizden çıkarsa listeden sil
    }
}
