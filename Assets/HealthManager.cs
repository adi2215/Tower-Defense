using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text balance;

    private void Awake() => LevelManager.OnUpdateHealth += UpdateHealth;

    private void UpdateHealth(int health)
    {
        balance.text = "Health: " + health.ToString();
    }
}
