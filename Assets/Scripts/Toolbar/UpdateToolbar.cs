using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateToolbar : MonoBehaviour
{
    public ToolbarObject toolbar;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;

    Dictionary<ToolbarSlot, GameObject> itemsDisplayed = new Dictionary<ToolbarSlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < toolbar.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(toolbar.Container[i]))
            {
                itemsDisplayed[toolbar.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = toolbar.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(toolbar.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = toolbar.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(toolbar.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < toolbar.Container.Count; i++)
        {
            var obj = Instantiate(toolbar.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = toolbar.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(toolbar.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMN)), 0f); 
    }
}
