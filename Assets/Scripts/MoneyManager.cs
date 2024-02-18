using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text balance;

    private void Awake() => LevelManager.OnUpdateBalance += UpdateBalance;

    private void UpdateBalance(int money)
    {
        balance.text = "Money: " + money.ToString() + "$";
    }
}
