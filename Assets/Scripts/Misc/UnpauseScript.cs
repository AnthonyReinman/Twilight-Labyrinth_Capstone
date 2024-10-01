using UnityEngine;

public class UnpauseScript : MonoBehaviour
{

    public LevelUpManager levelUpManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnpauseGame() {
        // Time.timeScale = 1.0f;
        levelUpManager.Resume();
    }
}
