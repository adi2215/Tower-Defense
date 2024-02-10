using UnityEngine;

public class SimpleSlime : EnemyStats
{
    public Color32 colorSlime = new Color32(230, 230, 230, 255);

    public void Init(int healthCount, int attackCount) 
    {
        _health = healthCount;
        _attackValue = attackCount;
    }

    public void Die() => Destroy(gameObject);
}
