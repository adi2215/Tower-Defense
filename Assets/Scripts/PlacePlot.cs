using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlot : MonoBehaviour
{
    [SerializeField] private GameObject[] selectPlot;

    private GameObject tower;

    private void Start() => TurnOff();

    private void OnMouseEnter()
    {
        TurnOn();
    }

    private void OnMouseDown() {
        Debug.Log("gef");
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
