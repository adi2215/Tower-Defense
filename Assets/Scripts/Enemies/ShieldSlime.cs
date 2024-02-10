using UnityEngine;

public class ShieldSlime : EnemyStats
{
    public Color32 colorSlime = new Color32(255, 128, 255, 255);

    public void Init(int healthCount, int attackCount) 
    {
        _health = healthCount;
        _attackValue = attackCount;
    }

    public void Die() => Destroy(gameObject);
}
