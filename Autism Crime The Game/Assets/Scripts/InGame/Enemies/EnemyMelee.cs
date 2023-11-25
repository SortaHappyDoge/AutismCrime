using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [Header("MeleeAttributes")]
    public float damage;
    public float attackSpeed;
    public float stun;
    public float knockback;
    public float bleed;
    float currentFatigue;
    public bool isEnabled;

    [Header("MeleeReferences")]
    public Collider2D attackCollider;
    public Transform player;
    StaminaBar staminaBar;
    AudioSource swing;

    private void Start()
    {
        attackCollider = transform.GetComponent<Collider2D>();
        staminaBar = GetComponent<StaminaBar>();
        swing = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        currentFatigue -= Time.fixedDeltaTime;
        staminaBar.StaminaRemap(currentFatigue, 0, attackSpeed);
    }

    public void ClickMessage()
    {
        if (!isEnabled) { return; }
        SwingMelee();
    }

    public void SwingMelee()
    {
        if (currentFatigue > 0) { return; }
        player.transform.GetComponent<PlayerManager>().GetMeleed(transform.position, damage, stun, knockback, bleed);
        swing.Play();
        currentFatigue = attackSpeed;
    }

        
    private void OnTriggerStay2D(Collider2D other)
    {
        SendMessage("ClickMessage");
    }
}
