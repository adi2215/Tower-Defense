using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [Header("UI")]
    public Image image;

    [HideInInspector] public Item item;

    public void InitialItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }
}
