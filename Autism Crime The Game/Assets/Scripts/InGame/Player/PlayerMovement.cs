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
    Vector3 mouseScreenPosition, mouseWorldPosition;

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
        //Karakter hareketi
        playerRb.AddForce(movementAxis * speed); //Karaktere hız ver
        playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity, maxSpeed); //Karakterin hızını limitle
        if (movementAxis.magnitude == 0) { ApplyFriction(); }
        //

        //Karakter rotasyonu
        mouseScreenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
        if(Physics.Raycast(ray, out RaycastHit hitData)) 
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(hitData.point.x - transform.position.x, hitData.point.y - transform.position.y, hitData.point.z - transform.position.z).normalized);
            transform.rotation.eulerAngles.Set(0,0, transform.rotation.eulerAngles.z);
        }
        //
    }

    private void ApplyFriction()
    {
        playerRb.velocity = playerRb.velocity * frictionMultiplier; //Sürtünme kuvvetiyle karakteri yavaşlat
        if(playerRb.velocity.magnitude < minimumSpeedClampingLimit) {playerRb.velocity = new Vector2();} //Hız belirli seviyenin altındaysa tamamen sıfırla
    }
}
