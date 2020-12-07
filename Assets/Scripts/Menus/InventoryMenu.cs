using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool InventoryOpen = false;

    public GameObject inventoryMenuUI;

    public GameObject reticle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public void Close()
    {
        inventoryMenuUI.SetActive(false);
        InventoryOpen = false;
        reticle.SetActive(true);
    }

    public void Open()
    {
        inventoryMenuUI.SetActive(true);
        InventoryOpen = true;
        reticle.SetActive(false);
    }
}
