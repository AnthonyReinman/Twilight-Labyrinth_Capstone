using UnityEngine;
using UnityEngine.UI;

public class MusicBtn : MonoBehaviour {

    public bool isEnabled = true;
    public Button btn;

    void Start() {
        int tmpEnabled = PlayerPrefs.GetInt("music_enabled", 0);
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
            PlayerPrefs.SetInt("music_enabled", -1);
        } else {
            PlayerPrefs.SetInt("music_enabled", 0);
        }
    }
}
