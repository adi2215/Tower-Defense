using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int enemyCount = 10;

    [SerializeField] private float delayBtwSpawn;

    private float _spawnTimer;
    private int _enemiesSpawn;

    private EnemyMaker _enemier;

    private void Start()
    {
        _enemier = GetComponent<EnemyMaker>();
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            _spawnTimer = delayBtwSpawn;
            if (_enemiesSpawn < enemyCount)
            {
                _enemiesSpawn++;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject newInstance = _enemier.GetInstanceFromEnemy();
        newInstance.SetActive(true);
    }
}
