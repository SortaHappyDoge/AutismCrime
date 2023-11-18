using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("ScriptReferences")]
    public PlayerMovement playerMovement;
    public ItemManager itemManager;

    void Update()
    {
        playerMovement.movementAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        itemManager.onClick = Input.GetAxisRaw("Fire1");
        if (Input.mouseScrollDelta.y != 0) { itemManager.SwitchItem(); }
    }
}
