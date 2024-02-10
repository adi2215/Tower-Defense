using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _attackValue;

    public void Die() => Destroy(gameObject);
}
