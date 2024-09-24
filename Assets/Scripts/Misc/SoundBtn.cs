using UnityEngine;
using UnityEngine.UI;

public class SoundBtn : MonoBehaviour {
    public bool isEnabled = true;
    public Button btn;

    void Start() {
        int tmpEnabled = PlayerPrefs.GetInt("sound_enabled", 0);
        if (tmpEnabled == -1) {
            isEnabled = false;
        }
    }

    void Update() {
        Text buttonText = btn.GetComponentInChildren<Text>();
        if (buttonText != null) {
            if (isEnabled) {
                buttonText.text = "Disable";
            } else {
                buttonText.text = "Enable";
            }
        }
    }

    public void Toggle() {
        isEnabled = !isEnabled;

        if (isEnabled == false) {
            PlayerPrefs.SetInt("sound_enabled", -1);
        } else {
            PlayerPrefs.SetInt("sound_enabled", 0);
        }
    }
}
