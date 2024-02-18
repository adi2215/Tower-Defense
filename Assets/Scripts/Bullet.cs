using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float moveSpeed = 10f;
    protected EnemyController _enemyTarget;
    private EnemyHealth _currentEnemy;

    public BulletTower BuildOwner { get; set; }
    public float Damage { get; set; }

    protected virtual void Update()
    {
        if (_enemyTarget != null)
        {
            MoveBullet();
        }
    }

    protected virtual void MoveBullet()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
        _enemyTarget.transform.position, moveSpeed * Time.deltaTime);
    }

    public void SetEnemy(EnemyController enemy)
    {
        _enemyTarget = enemy;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_currentEnemy = collider.GetComponent<EnemyHealth>())
        {
            _currentEnemy.SmileDamage(Damage);
            
            Destroy(gameObject, 0.05f);
        }
    }
}
