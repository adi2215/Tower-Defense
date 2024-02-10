using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabTowers;

    private List<ActionType> typesObject;

    Dictionary<ActionType, GameObject> towerKeys;

    private void Start()
    {
        typesObject = new List<ActionType>();

        towerKeys = new Dictionary<ActionType, GameObject>(); 

        for (int i = 0; i < prefabTowers.Length; i++)
        {
            Item item = prefabTowers[i].GetComponent<PlayerAnimate>().itemTower;
            typesObject.Add(item.type);

            towerKeys.Add(typesObject[i], prefabTowers[i]);
        }
    }

    private void OnEnable() 
    {
        PlacePlot.OnBuild += BuildingTower;
    }

    private void OnDisable() 
    {
        PlacePlot.OnBuild -= BuildingTower;
    }

    private void BuildingTower(object sender, PlacePlot.OnBuildEventsArgs e)
    {
        Instantiate(towerKeys[e.item.type], e.positionPlot, Quaternion.identity);
        Destroy(e.plot);
    }
}
