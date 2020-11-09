using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Toolbar : MonoBehaviour
{
    public Player player;

    public RectTransform highlight;
    public ItemSlot[] itemSlots;
}

[System.Serializable]
public class ItemSlot
{
    public byte itemID;
    public Image icon;
}