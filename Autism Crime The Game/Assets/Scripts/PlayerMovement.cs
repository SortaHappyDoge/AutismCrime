using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("MovementAttributes")]
    public float speed;
    [Range(0.0f, 1.0f)]
    public float frictionMultiplier;

    [Header("MovementReferences")]
    public Transform player;
    Rigidbody2D playerRb;
    public Vector2 movementAxis;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movementAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void FixedUpdate()
    {
        playerRb.AddForce(movementAxis * speed);
        ApplyFriction();
    }

    private void ApplyFriction()
    {
        playerRb.velocity = playerRb.velocity * frictionMultiplier;
    }
}
