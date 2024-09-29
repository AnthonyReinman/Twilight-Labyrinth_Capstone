using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour {

    public PermBuffManager buffManager;
    public Button button;
    private string type;
    private int level;
    private bool isEnabled = false;
    private bool alreadyOwned = false;

    void Start() {
        string objectName = gameObject.name;
        // Debug.Log("The name of this GameObject is: " + objectName);
        string[] nameParts = objectName.Split('_');
        this.type = nameParts[0];
        this.level = Int32.Parse(nameParts[2]);
        // Debug.Log("this.type: " + this.type);
        // Debug.Log("this.level: " + this.level);
        if (button != null) {
            button.onClick.AddListener(ClickBtn);
        }
    }

    void Update() {
        Image buttonImage = button.GetComponent<Image>();
        if (this.type != null && this.level != null) {
            if (type == "HU") {
                int tmpCurrLvl = buffManager.healthBuffManager.GetCurrentLevel();
                int nextLevel = tmpCurrLvl+1;
                Debug.Log("HU Updated - this.level: " + this.level);
                Debug.Log("HU Updated - tmpCurrLvl: " + tmpCurrLvl);
                Debug.Log("HU Updated - nextLevel: " + nextLevel);
                if (this.level == nextLevel) {
                    buttonImage.color = Color.green;
                    button.interactable = true;

                    if (buffManager.healthBuffManager.CanAffordUpgrade()) {
                        buttonImage.color = Color.green;
                        button.interactable = true;
                    } else {
                        buttonImage.color = Color.red;
                        button.interactable = false;
                    }

                    return;
                } else {
                    button.interactable = false;
                    if (this.level <= tmpCurrLvl) {
                        buttonImage.color = Color.blue;
                        return;
                    } else {
                        buttonImage.color = Color.gray;
                        return;
                    }
                }
            } else if (type == "AS") {
                int tmpCurrLvl = buffManager.attackSpeedBuffManager.GetCurrentLevel();
                int nextLevel = tmpCurrLvl+1;
                if (this.level == nextLevel) {
                    buttonImage.color = Color.green;
                    button.interactable = true;

                    if (buffManager.attackSpeedBuffManager.CanAffordUpgrade()) {
                        buttonImage.color = Color.green;
                        button.interactable = true;
                    } else {
                        buttonImage.color = Color.red;
                        button.interactable = false;
                    }

                    return;
                } else {
                    button.interactable = false;
                    if (this.level <= tmpCurrLvl) {
                        buttonImage.color = Color.blue;
                        return;
                    } else {
                        buttonImage.color = Color.gray;
                        return;
                    }
                }
            } else if (type == "AD") {
                int tmpCurrLvl = buffManager.attackDamageManager.GetCurrentLevel();
                int nextLevel = tmpCurrLvl+1;
                if (this.level == nextLevel) {
                    buttonImage.color = Color.green;
                    button.interactable = true;

                    if (buffManager.attackDamageManager.CanAffordUpgrade()) {
                        buttonImage.color = Color.green;
                        button.interactable = true;
                    } else {
                        buttonImage.color = Color.red;
                        button.interactable = false;
                    }

                    return;
                } else {
                    button.interactable = false;
                    if (this.level <= tmpCurrLvl) {
                        buttonImage.color = Color.blue;
                        return;
                    } else {
                        buttonImage.color = Color.gray;
                        return;
                    }
                }
            } else if (type == "MS") {
                int tmpCurrLvl = buffManager.moveSpeedBuffManager.GetCurrentLevel();
                int nextLevel = tmpCurrLvl+1;
                if (this.level == nextLevel) {
                    buttonImage.color = Color.green;
                    button.interactable = true;

                    if (buffManager.moveSpeedBuffManager.CanAffordUpgrade()) {
                        buttonImage.color = Color.green;
                        button.interactable = true;
                    } else {
                        buttonImage.color = Color.red;
                        button.interactable = false;
                    }

                    return;
                } else {
                    button.interactable = false;
                    if (this.level <= tmpCurrLvl) {
                        buttonImage.color = Color.blue;
                        return;
                    } else {
                        buttonImage.color = Color.gray;
                        return;
                    }
                }
            }
        }
    }

    public void ClickBtn() {
        Debug.Log("TEST???");
        if (type == "HU") {
            Debug.Log("TEST A!");
            buffManager.healthBuffManager.LevelUp();
        } else if (type == "AS") {
            Debug.Log("TEST B!");
            buffManager.attackSpeedBuffManager.LevelUp();
        } else if (type == "AD") {
            Debug.Log("TEST C!");
            buffManager.attackDamageManager.LevelUp();
        } else if (type == "MS") {
            Debug.Log("TEST D!");
            buffManager.moveSpeedBuffManager.LevelUp();
        }
    }
}
