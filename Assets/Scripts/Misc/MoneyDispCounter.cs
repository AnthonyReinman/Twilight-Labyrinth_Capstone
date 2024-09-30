using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDispCounter : MonoBehaviour {

    public TMP_Text title;
    public CurrencyManager currencyManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (title != null) {
            title.text = "Currency: $" + currencyManager.GetBalance();
        }
    }
}
