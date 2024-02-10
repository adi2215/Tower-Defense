using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    internal static EnemyMaker _instance;
    public GameObject prefab;
    private EnemyFactory _currentFactory;

    private int randomSlime;
    [SerializeField] private int enemySize = 10;
    private List<GameObject> _enemy;
    [SerializeField] private GameObject _enemyContainer;
    private List<MethodInfo> methods;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        _currentFactory = new SmileUnitsFactory();
        _enemy = new List<GameObject>();
        methods = new List<MethodInfo>(_currentFactory.GetType().GetMethods());

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
        randomSlime = UnityEngine.Random.Range(1, methods.Count - 4);

        GameObject newEnemy = _currentFactory.CreateSmile(methods[randomSlime].Name);

        newEnemy.transform.SetParent(_enemyContainer.transform);
        newEnemy.transform.position = _enemyContainer.transform.position;
        newEnemy.SetActive(false);
        
        return newEnemy;
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
        instance.GetComponent<EnemyStats>().Die();
    }

    public static IEnumerator ReturnToEnemyDelay(GameObject instance, float delay)
    {
        yield return new WaitForSeconds(delay);
        instance.SetActive(false);
    }
}


public class SmileUnitsFactory : EnemyFactory
{
    public override GameObject CreateSmile(string nameSmile)
    {
        GameObject newSmile = null;

        switch (nameSmile)
        {
            case "CreateSimple":
                newSmile = CreateSimple();
                break;
            
            case "CreateShield":
                newSmile = CreateShield();
                break;

            case "CreatePowerFly":
                newSmile = CreatePowerFly();
                break;
        }

        return newSmile;
    }

    public override GameObject CreateSimple()
    {
        GameObject newInstance = GameObject.Instantiate(EnemyMaker._instance.prefab);
        newInstance.AddComponent<SimpleSlime>();
        SimpleSlime simple = newInstance.GetComponent<SimpleSlime>();
        SpriteRenderer spriteColor = newInstance.GetComponent<SpriteRenderer>();
        spriteColor.color = simple.colorSlime;
        simple.Init(1, 1);
        
        Person<SimpleSlime> newTupleEnemy = 
        new Person<SimpleSlime>(simple, newInstance);

        return newTupleEnemy.enemyObject;
    }

    public override GameObject CreateShield()
    {
        GameObject newInstance = GameObject.Instantiate(EnemyMaker._instance.prefab);
        newInstance.AddComponent<ShieldSlime>();
        ShieldSlime shield = newInstance.GetComponent<ShieldSlime>();
        SpriteRenderer spriteColor = newInstance.GetComponent<SpriteRenderer>();
        spriteColor.color = shield.colorSlime;
        shield.Init(2, 1);

        Person<ShieldSlime> newTupleEnemy = 
        new Person<ShieldSlime>(shield, newInstance);

        return newTupleEnemy.enemyObject;
    }

    public override GameObject CreatePowerFly()
    {
        GameObject newInstance = GameObject.Instantiate(EnemyMaker._instance.prefab);
        newInstance.AddComponent<PowerFlySlime>();
        PowerFlySlime powerFly = newInstance.GetComponent<PowerFlySlime>();
        SpriteRenderer spriteColor = newInstance.GetComponent<SpriteRenderer>();
        spriteColor.color = powerFly.colorSlime;
        powerFly.Init(1, 2);

        Person<PowerFlySlime> newTupleEnemy = 
        new Person<PowerFlySlime>(powerFly, newInstance);

        return newTupleEnemy.enemyObject;
    }
}

class Person<T>
{
    public T enemyId { get; set; }
    public GameObject enemyObject { get; set; }
    public Person(T id, GameObject ObjectEnemy)
    {
        enemyId = id; 
        enemyObject = ObjectEnemy;
    }
}


