using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [Header("SpriteReferences")]
    public Transform playerBody;

    [Header("SpriteAttributes")]
    public float lookway = 1;

    private void Update()
    {
        transform.position = playerBody.position;
        if(playerBody.GetComponent<PlayerMovement>().movementAxis.x != lookway && playerBody.GetComponent<PlayerMovement>().movementAxis.x != 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            lookway = playerBody.GetComponent<PlayerMovement>().movementAxis.x;
        }
    }
}
