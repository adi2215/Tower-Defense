using UnityEngine;

public class PowerFlySlime : EnemyStats
{
    public Color32 colorSlime = new Color32(175, 190, 135, 255);

    public void Init(int healthCount, int attackCount) 
    {
        _health = healthCount;
        _attackValue = attackCount;
    }
}
