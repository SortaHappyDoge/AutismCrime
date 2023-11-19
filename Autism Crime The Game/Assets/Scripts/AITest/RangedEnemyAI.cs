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
    float distanceToTarget;
    float lastX;
    float lastY;

    [Header("AIReferences")]
    public Transform player;
    public Animator animator;
    public GunPlaceholder weapon;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        isStunned = GetComponent<EnemyManager>().isStunned;
        if (isStunned) { agent.isStopped = true; animator.SetFloat("X", 0); animator.SetFloat("Y", 0); return; }

        //Karakterimize uzaklığı bul
        distanceToTarget = new Vector2(
        target.position.x - transform.position.x,
        target.position.y - transform.position.y
        ).magnitude;
        //
        if (distanceToTarget < shootDistance)
        {
            weapon.SendMessage("ClickMessage");
            agent.isStopped = true;
        }
        else { agent.isStopped = false; }


        //Animasyon
        if (lastX - transform.position.x < lastY - transform.position.y && lastX > transform.position.x) { animator.SetFloat("X", -1); animator.SetFloat("Y", 0); }
        if (lastX - transform.position.x > lastY - transform.position.y && lastY > transform.position.y) { animator.SetFloat("X", 0); animator.SetFloat("Y", -1); }
        if (lastX - transform.position.x < lastY - transform.position.y && lastX < transform.position.x) { animator.SetFloat("X", 1); animator.SetFloat("Y", 0); }
        if (lastX - transform.position.x > lastY - transform.position.y && lastY < transform.position.y) { animator.SetFloat("X", 0); animator.SetFloat("Y", 1); }
        //

        agent.SetDestination(target.position);
        lastX = transform.position.x; lastY = transform.position.y;
    }
}
