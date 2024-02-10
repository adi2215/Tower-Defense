using UnityEngine;
using System;

public class PlacePlot : MonoBehaviour
{
    public static event EventHandler<OnBuildEventsArgs> OnBuild;
    public class OnBuildEventsArgs : EventArgs { 
        public Item item;
        public Vector3 positionPlot;
        public GameObject plot;
    }

    [SerializeField] private GameObject[] selectPlot;

    private void Start() => TurnOff();

    private void OnMouseEnter()
    {
        TurnOn();
    }

    private void OnMouseDown() {
        InventorySlot slot = InventoryManager.instance.inventorySlot;
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

        if (itemInSlot != null)
            OnBuild?.Invoke(this, new OnBuildEventsArgs { item = itemInSlot.item, 
            positionPlot = transform.position, 
            plot = gameObject });
    }

    private void OnMouseExit()
    {
        TurnOff();
    }

    private void TurnOff()
    {
        selectPlot[0].SetActive(false);
        selectPlot[1].SetActive(false);
    }

    private void TurnOn()
    {
        selectPlot[0].SetActive(true);
        selectPlot[1].SetActive(true);
    }
}
