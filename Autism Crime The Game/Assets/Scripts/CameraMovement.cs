using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("MovementAttributes")]
    public float speed;
    [Range(0.0f, 100.0f)]
    public float speedPercentage;
    [Range(0.0f, 1.0f)]
    public float playerLead;

    [Header("MovementReferences")]
    public Transform player;
    public Transform camera;
    public Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 startPosition = camera.position;
        Vector2 targetPosition = player.position;

        
    }
}
