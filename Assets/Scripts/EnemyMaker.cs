using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int enemySize = 10;
    private List<GameObject> _enemy;
    [SerializeField] private GameObject _enemyContainer;

    private void Awake()
    {
        _enemy = new List<GameObject>();
        CreateMakerEnemy();
    }

    private void CreateMakerEnemy()
    {
        for (int i = 0; i < enemySize; i++)
        {
            _enemy.Add(CreateInstance());
        }
    }

    private GameObject CreateInstance()
    {
        GameObject newInstance = Instantiate(prefab);
        newInstance.transform.SetParent(_enemyContainer.transform);
        newInstance.transform.position = _enemyContainer.transform.position;
        newInstance.SetActive(false);
        return newInstance;
    }

    public GameObject GetInstanceFromEnemy()
    {
        for (int i = 0; i < _enemy.Count; i++)
        {
            if (!_enemy[i].activeInHierarchy)
            {
                return _enemy[i];
            }
        }
        
        return CreateInstance();
    }

    public static void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
    }

    public static IEnumerator ReturnToEnemyDelay(GameObject instance, float delay)
    {
        yield return new WaitForSeconds(delay);
        instance.SetActive(false);
    }
}
