using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/New Food Item")]
public class FoodItem : ItemScriptableObject
{
    private void Start()
    {
        itemType = ItemType.Food;
    }


}
