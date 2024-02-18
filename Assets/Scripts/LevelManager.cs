using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static Action<int> OnUpdateBalance;
    public static Action<int> OnUpdateHealth;

    public static LevelManager instanceSingleton;

    [SerializeField] private int lives = 10;

    public int TotalLives { get; set; }

    public int CurrentWave { get; set; }

    public int CountMoney { get; set; }

    private void Awake()
    {
        CreateSingleton();
    }

    private void CreateSingleton()
    {
        if (instanceSingleton == null)
            instanceSingleton = this;

        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        TotalLives = lives;
        CurrentWave = 1;
        CountMoney = 25;
        OnUpdateBalance?.Invoke(CountMoney);
        OnUpdateHealth?.Invoke(TotalLives); 
    }

    private void OnEnable() {
        EnemyController.onEndReach += ReduceLives;
    }

    private void OnDisable() {
        EnemyController.onEndReach -= ReduceLives;
    }

    private void ReduceLives(EnemyController enemy)
    {
        int attackSlime = enemy.gameObject.GetComponent<EnemyStats>()._attackValue;

        TotalLives -= attackSlime;
        OnUpdateHealth?.Invoke(TotalLives); 

        if (TotalLives <= 0)
        {
            TotalLives = 0;
            GameOver();
        }
    }

    public bool BuyingBuild(int cost)
    {
        if (cost <= CountMoney)
        {
            CountMoney -= cost;
            OnUpdateBalance?.Invoke(CountMoney); 
            return true;
        }

        return false;
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
