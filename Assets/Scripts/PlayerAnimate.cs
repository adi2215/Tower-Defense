using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public Item itemTower;
    private EnemyController newEnemy;
    public EnemyController GetCurrentEnemyTarget;
    public List<EnemyController> _enemies = new List<EnemyController>();


    private void OnTriggerEnter2D(Collider2D other) {
        if (newEnemy = other.GetComponent<EnemyController>())
        {
            _enemies.Add(newEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (newEnemy = other.GetComponent<EnemyController>())
        {
            if (_enemies.Contains(newEnemy))
            {
                _enemies.Remove(newEnemy);
            }
        }
    }

    private void Update()
    {
        GetCurrentEnemy();
    }

    private void GetCurrentEnemy()
    {
        if (_enemies.Count <= 0)
        {
            GetCurrentEnemyTarget = null;
            return;
        }

        GetCurrentEnemyTarget = _enemies[0];
    }
}
