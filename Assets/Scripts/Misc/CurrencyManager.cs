using UnityEngine;

public class CurrencyManager : MonoBehaviour {

    private float currentBalance = 0f;

    void Start() {
        currentBalance = PlayerPrefs.GetFloat("moneyBalance");

        // -- For Testing and Demo Purposes, don't forget to reset to 0 & comment out! --
            // Debug.Log("[TESTING] Setting perm ability values...");
            PlayerPrefs.SetFloat("moveSpeedBuff", 0.0f);
            PlayerPrefs.SetFloat("attackSpeedBuff", 0.0f);
            PlayerPrefs.SetFloat("attackDamageBuff", 10.0f);
            PlayerPrefs.SetFloat("playerHealthBuff", 50.0f);
            PlayerPrefs.SetFloat("moneyBalance", 750.0f);
        // ----- Reset -----
            // Debug.Log("[TESTING] Resetting perm ability values...");
            // PlayerPrefs.SetFloat("moveSpeedBuff", 0.0f);
            // PlayerPrefs.SetFloat("attackSpeedBuff", 0.0f);
            // PlayerPrefs.SetFloat("attackDamageBuff", 0.0f);
            // PlayerPrefs.SetFloat("playerHealthBuff", 0.0f);
            // PlayerPrefs.SetFloat("moneyBalance", 0.0f);
        // -------------------------------------------------------------------------------
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
