using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    internal static InventoryManager instance;

    public InventorySlot inventorySlot;
    public GameObject inventoryItemPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddItem(Item item)
    {
        InventorySlot slot = inventorySlot;
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

        if (itemInSlot == null && LevelManager.instanceSingleton.BuyingBuild(item.cost))
            SpawnItem(item, slot);
        
    }

    private void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialItem(item);
    }

    internal void DeleteItem()
    {
        InventorySlot slot = inventorySlot;
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

        if (itemInSlot != null)
            Destroy(itemInSlot.gameObject);
    }
}
