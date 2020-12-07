using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Thirst Object", menuName = "Inventory System/Items/Thirst")]
public class ThirstObject : ItemObject
{
    public int restoreThirstValue;

    void Awake()
    {
        type = ItemType.Thirst;
    }
}