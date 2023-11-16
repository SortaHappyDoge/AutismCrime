using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("ItemAttributes")]
    public Transform holdedItem;
    public float onClick;

    private void Update()
    {
        if(holdedItem != null && onClick == 1) { holdedItem.SendMessage("ClickMessage"); }
        //else if(holdedItem != null) { holdedItem.SendMessage("NotClickedMessage"); }
    }
}
