using UnityEngine;

public class BulletTower : MonoBehaviour
{
    [SerializeField] protected Transform bulletSpawnPosition;
    [SerializeField] protected float delayAttack = 2f;
    [SerializeField] protected float damage = 2f;

    public GameObject prefabBullet;

    public float Damage { get; set; }

    public float DelayPerShot { get; set; }
    protected float _nextAttackTime;
    protected PlayerAnimate _build;
    protected Bullet _currentBulletLoaded;

    private void Start()
    {
        _build = GetComponent<PlayerAnimate>();

        Damage = damage;
        DelayPerShot = delayAttack;
        MakeBullet();
    }

    protected virtual void Update()
    {
        if (_currentBulletLoaded == null)
        {
            MakeBullet();
        }
        if (Time.time > _nextAttackTime)
        {
            if (_build.GetCurrentEnemyTarget != null && _currentBulletLoaded != null
                && _build.GetCurrentEnemyTarget.gameObject.GetComponent<EnemyHealth>().CurrentHealth > 0f)
            {
                _currentBulletLoaded.transform.parent = null;
                _currentBulletLoaded.SetEnemy(_build.GetCurrentEnemyTarget);
            }
            _nextAttackTime = Time.time + DelayPerShot;
        }
    }

    protected virtual void MakeBullet()
    {
        GameObject newInstance = Instantiate(prefabBullet, bulletSpawnPosition.position, Quaternion.identity);
        newInstance.transform.SetParent(bulletSpawnPosition);

        _currentBulletLoaded = newInstance.GetComponent<Bullet>();
        _currentBulletLoaded.Damage = Damage;
    }
 }
