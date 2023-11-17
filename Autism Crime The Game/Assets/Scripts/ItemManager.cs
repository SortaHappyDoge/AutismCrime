using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("ItemAttributes")]
    public Transform holdedItem;
    public float onClick;
    
    [Header("ItemReferences")]
    public List<Transform> inventory = new List<Transform>();

    private void Start()
    {
        holdedItem = inventory[1];
        if (holdedItem == inventory[0]) { holdedItem.gameObject.SetActive(false); holdedItem = inventory[1]; holdedItem.gameObject.SetActive(true); } else { holdedItem.gameObject.SetActive(false); holdedItem = inventory[0]; holdedItem.gameObject.SetActive(true); }
    }
    private void FixedUpdate()
    {
        if(holdedItem != null && onClick == 1) { holdedItem.SendMessage("ClickMessage"); }
    }

    public void SwitchItem()
    {
        if(holdedItem == inventory[0]) { holdedItem.gameObject.SetActive(false); holdedItem = inventory[1]; holdedItem.gameObject.SetActive(true); } else { holdedItem.gameObject.SetActive(false); holdedItem = inventory[0]; holdedItem.gameObject.SetActive(true); }
    }
}
