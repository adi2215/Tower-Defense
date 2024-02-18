using UnityEngine;

public class ShieldSlime : EnemyStats
{
    public Color32 colorSlime = new Color32(252, 169, 255, 255);

    public void Init(int healthCount, int attackCount) 
    {
        _health = healthCount;
        _attackValue = attackCount;
    }
}
