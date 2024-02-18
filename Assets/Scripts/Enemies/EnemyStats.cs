using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] internal int _health;
    [SerializeField] internal int _attackValue;

    public void Die() => Destroy(gameObject);
}
