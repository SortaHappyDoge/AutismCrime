using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("EnemyAttributes")]
    public Transform target;
    public bool isStunned;
    float lastX;
    float lastY;

    [Header("EnemyReferences")]
    public Transform sprite;
    NavMeshAgent agent;
    Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = sprite.GetComponent<Animator>();
    }

    private void Update()
    {
        isStunned = GetComponent<EnemyManager>().isStunned;
        if (isStunned) { agent.isStopped = true; animator.SetFloat("X", 0); animator.SetFloat("Y", 0); return; }
        
        agent.isStopped = false;
        agent.SetDestination(target.position);
        
        //Animasyon
        if(lastX - transform.position.x < lastY - transform.position.y && lastX > transform.position.x) { animator.SetFloat("X", -1); animator.SetFloat("Y", 0); }
        if (lastX - transform.position.x > lastY - transform.position.y && lastY > transform.position.y) { animator.SetFloat("X", 0); animator.SetFloat("Y", -1); }
        if (lastX - transform.position.x < lastY - transform.position.y && lastX < transform.position.x) { animator.SetFloat("X", 1); animator.SetFloat("Y", 0); }
        if (lastX - transform.position.x > lastY - transform.position.y && lastY < transform.position.y) { animator.SetFloat("X", 0); animator.SetFloat("Y", 1); }
        //

        lastX = transform.position.x; lastY = transform.position.y;
    }
}
