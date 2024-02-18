using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float initialHealth;

    public float CurrentHealth { get; set; }

    public Image _healthBar;
    private EnemyController _enemy;

    private void Start()
    {
        initialHealth = gameObject.GetComponent<EnemyStats>()._health;
        CurrentHealth = initialHealth;

        _enemy = GetComponent<EnemyController>();
    }

    private void Update()
    {
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, 
        CurrentHealth / initialHealth, Time.deltaTime * 10f);
    }

    public void SmileDamage(float valueDamage)
    {
        CurrentHealth -= valueDamage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            EnemyMaker.ReturnToPool(gameObject);
        }
        else
        {
            Debug.Log("EnemyHit");
        }
    }
}
