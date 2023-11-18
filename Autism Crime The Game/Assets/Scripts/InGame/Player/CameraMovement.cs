using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("MovementAttributes")]
    [Range(0.0f, 1.0f)]
    public float speed;
    [Range(0.0f, 10.0f)]
    public float playerLead;

    [Header("MovementReferences")]
    public Transform player;
    public Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = player.position;

        Vector2 newPosition = Vector2.Lerp(transform.position, targetPosition, speed);
        transform.position = new Vector3(newPosition.x, newPosition.y, -10);
    }
}
