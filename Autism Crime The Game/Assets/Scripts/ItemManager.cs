using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("ItemAttributes")]
    public Transform holdedItem;
    public float onClick;

    private void FixedUpdate()
    {
        if(holdedItem != null && onClick == 1) { holdedItem.SendMessage("ClickMessage"); }
    }
}
