using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDeletion : MonoBehaviour
{
    Animator animator;
    public float timer = 0.5f;
    private void Update()
    {
        if (timer < 0)
        {
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;
    }
}
