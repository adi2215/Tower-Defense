using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "TowerDefence/Item", order = 0)]
public class Item : ScriptableObject {
    public Sprite image;
    public ActionType type;
    public int cost;
}

public enum ActionType {
    Sofia,
    Totem,
    Zombie
}

