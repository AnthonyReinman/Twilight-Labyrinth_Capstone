using UnityEngine;

public class LevelUpTest : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;

    private LevelUpManager levelUpManager;

    void Start()
    {
        levelUpManager = FindObjectOfType<LevelUpManager>();
    }

    void Update()
    {
        // Test input to simulate gaining XP
        if (Input.GetKeyDown(KeyCode.X))
        {
            GainXP(50); // Press 'X' to gain 50 XP
        }
    }

    public void GainXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel++;
        currentXP -= xpToNextLevel; // Carry over any extra XP
        xpToNextLevel += 50; // Increase the required XP for the next level

        // Trigger the level-up UI
        levelUpManager.TriggerLevelUp();
    }
}
