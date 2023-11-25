using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyAI : MonoBehaviour
{
    [Header("AIAttributes")]
    public Transform target; //Karakterimiz
    public bool isStunned;
    public float shootDistance;
    public bool stunAble = true;
    float distanceToTarget;
    float lastX;
    float lastY;
    //Ray2D ray;

    [Header("AIReferences")]
    public Transform player;
    public Animator animator;
    public Transform weapon;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        isStunned = GetComponent<EnemyManager>().isStunned;
        if (isStunned && stunAble) { agent.isStopped = true; animator.SetFloat("X", 0); animator.SetFloat("Y", 0); return; }

        //Karakterimize uzaklığı bul
        distanceToTarget = new Vector2(
        target.position.x - transform.position.x,
        target.position.y - transform.position.y
        ).magnitude;
        //

        //ray = new Ray2D(transform.position, transform.position - target.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, (target.position-transform.position).normalized, Mathf.Infinity, 1 << 9 | 1 << 11);
        if (distanceToTarget < shootDistance && hit.transform.CompareTag("Player"))
        {
            weapon.SendMessage("ClickMessage");
            agent.isStopped = true;
        }
        else { agent.isStopped = false; }


        //Animasyon 
        if (animator != null)
        {
            if (lastX - transform.position.x < lastY - transform.position.y && lastX > transform.position.x) { animator.SetFloat("X", -1); animator.SetFloat("Y", 0); }
            if (lastX - transform.position.x > lastY - transform.position.y && lastY > transform.position.y) { animator.SetFloat("X", 0); animator.SetFloat("Y", -1); }
            if (lastX - transform.position.x < lastY - transform.position.y && lastX < transform.position.x) { animator.SetFloat("X", 1); animator.SetFloat("Y", 0); }
            if (lastX - transform.position.x > lastY - transform.position.y && lastY < transform.position.y) { animator.SetFloat("X", 0); animator.SetFloat("Y", 1); }
            if (lastX - transform.position.x == 0 && lastY - transform.position.y == 0) { animator.SetFloat("X", 0); animator.SetFloat("Y", 0); }
        }
        //

        agent.SetDestination(target.position);
        lastX = transform.position.x; lastY = transform.position.y;
    }
}
