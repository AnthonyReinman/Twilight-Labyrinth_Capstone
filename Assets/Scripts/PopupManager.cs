using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public LevelUpManager LevelUpManager;
    void Start()
    {
        Debug.Log("Game Start: Showing How To Play Popup");
        ShowHowToPlay();
    }

    public void ShowHowToPlay()
    {
        Debug.Log("Showing How To Play Panel and Pausing Game");
        howToPlayPanel.SetActive(true);
        LevelUpManager.Pause(); // Pause the game
    }

    public void CloseHowToPlay()
    {
        Debug.Log("Closing How To Play Panel and Resuming Game");
        LevelUpManager.Resume(); // Resume the game
        howToPlayPanel.SetActive(false);
        
    }
}
