using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int space = 10;
    public List<InventoryItem> items = new List<InventoryItem>();
    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public void Add(InventoryItem item)
    {
        if (item.showIntenvory)
        {
            if (items.Count >= space)
                return;
            items.Add(item);
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
    }
    public void Remove(InventoryItem item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
