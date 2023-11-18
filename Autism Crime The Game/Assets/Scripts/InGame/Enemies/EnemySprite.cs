using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{
    [Header("SpriteReferences")]
    public Transform enemyBody;

    [Header("SpriteAttributes")]
    public float lookway = 1;
    float lastPos;

    private void Update()
    {
        transform.position = enemyBody.position;

        if(lastPos < enemyBody.position.x && lookway == -1)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            lookway = 1;
        }
        else if (lastPos > enemyBody.position.x && lookway == 1)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            lookway = -1;
        }
        
        /*if (enemyBody.GetComponent<PlayerMovement>().movementAxis.x != lookway && enemyBody.GetComponent<PlayerMovement>().movementAxis.x != 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            lookway = enemyBody.GetComponent<PlayerMovement>().movementAxis.x;
        }*/
        lastPos = enemyBody.position.x;
    }
}
