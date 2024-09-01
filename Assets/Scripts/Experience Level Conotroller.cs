using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelConotroller : MonoBehaviour
{
    public static ExperienceLevelConotroller instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int currentExperience;

    public ExpPickup pickup;

    public List<int> expLevels;
    public int currentLevel = 1, levelCount = 100;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the first experience level if expLevels is empty
        if (expLevels.Count == 0)
        {
            expLevels.Add(5); // For example, the first level requires 5 XP
            Debug.Log("First level initialized with 5 XP");

        }

        // Now, generate the remaining levels
        while (expLevels.Count < levelCount)
        {
            int lastExpLevel = expLevels[expLevels.Count - 1];
            expLevels.Add(Mathf.CeilToInt(lastExpLevel * 1.1f)); // Increase experience requirement by 10%
            Debug.Log("Added level with experience requirement: " + expLevels[expLevels.Count - 1]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;
        if(currentExperience >= expLevels[currentLevel])
        {
            LevelUp();
        }
        if (UIController.instance != null)
        {
            UIController.instance.UpdateExperience(currentExperience, expLevels[currentLevel], currentLevel);
        }
        else
        {
            Debug.LogError("UIController reference is not assigned.");
        }
    }

    public void SpawnExp(Vector3 position)
    {
        // Check if the pickup prefab reference is missing
        if (pickup == null)
        {
            // Try loading the prefab dynamically from Resources folder
            pickup = Resources.Load<ExpPickup>("PathToExpPickupPrefab"); // Replace "PathToExpPickupPrefab" with the correct path

            // If it's still null after attempting to load, log an error and return
            if (pickup == null)
            {
                Debug.LogError("ExpPickup prefab reference is missing, and Resources.Load failed to retrieve it!");
                return;
            }
        }

        // Instantiate the pickup at the given position
        Instantiate(pickup, position, Quaternion.identity);
        Debug.Log("ExpPickup spawned at position: " + position);
    }
    void LevelUp()
    {
        currentExperience -= expLevels[currentLevel];
    currentLevel++;

    if (currentLevel >= expLevels.Count)
    {
        currentLevel = expLevels.Count - 1;
    }

    // Trigger the level-up process, like displaying UI, giving rewards, etc.
    Debug.Log("Player leveled up to level " + currentLevel);

    // Trigger the ability selection panel
    if (LevelUpManager.instance != null)
    {
        LevelUpManager.instance.TriggerLevelUp();
    }
    else
    {
        Debug.LogError("LevelUpManager instance is not assigned.");
    }
    
    }
}
