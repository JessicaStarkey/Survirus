using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Toolbar")]
public class ToolbarObject : ScriptableObject
{
    public List<ToolbarSlot> Container = new List<ToolbarSlot>();

    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            Container.Add(new ToolbarSlot(_item, _amount));
        }
    }
}

[System.Serializable]
public class ToolbarSlot
{
    public ItemObject item;
    public int amount;
    public ToolbarSlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
