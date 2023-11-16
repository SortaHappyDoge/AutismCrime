using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("MovementAttributes")]
    public float speed;
    public float maxSpeed;
    [Range(0.0f, 1.0f)]
    public float frictionMultiplier;

    [Header("MovementReferences")]
    public Transform player;
    Rigidbody2D playerRb;
    public Vector2 movementAxis;
    public float minimumSpeedClampingLimit;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        playerRb.AddForce(movementAxis * speed); //Karaktere hız ver
        playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity, maxSpeed); //Karakterin hızını limitle
        if (movementAxis.magnitude == 0) { ApplyFriction(); }
    }

    private void ApplyFriction()
    {
        playerRb.velocity = playerRb.velocity * frictionMultiplier; //Sürtünme kuvvetiyle karakteri yavaşlat
        if(playerRb.velocity.magnitude < minimumSpeedClampingLimit) {playerRb.velocity = new Vector2();} //Hız belirli seviyenin altındaysa tamamen sıfırla
    }
}
