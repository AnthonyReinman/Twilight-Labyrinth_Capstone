using UnityEngine;

public class CurrencyManager : MonoBehaviour {

    private float currentBalance = 0f;

    void Start() {
        currentBalance = PlayerPrefs.GetFloat("moneyBalance");
    }

    public float GetBalance() {
        return currentBalance;
    }

    // TODO increase on level complete 
    public void IncreaseBalance(float amount) {
        currentBalance += amount;
        UpdatePlayerPrefs();
    }

    // TODO decrease on purchases
    public void DecreaseBalance(float amount) {
        currentBalance -= amount;
        UpdatePlayerPrefs();
    }

    private void UpdatePlayerPrefs() {
        PlayerPrefs.SetFloat("moneyBalance", currentBalance);
    }

}
