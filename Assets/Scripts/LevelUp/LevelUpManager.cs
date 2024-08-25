using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LevelUpManager : MonoBehaviour
{
    public GameObject levelUpPanel;
    public Button option1Button;
    public Button option2Button;
    public Button option3Button;

    private bool isPaused = false;
    private PlayerAbilities playerAbilities;

    void Start()
    {
        levelUpPanel.SetActive(false); // Hide the panel at start

        playerAbilities = FindObjectOfType<PlayerAbilities>();

        // Ensure all references are assigned
        if (option1Button == null || option2Button == null || option3Button == null)
        {
            Debug.LogError("Button references are not assigned in the Inspector!");
            return;
        }

        // Add listeners to buttons
        option1Button.onClick.AddListener(() => SelectUpgrade(option1Button.GetComponentInChildren<TextMeshProUGUI>().text));
        option2Button.onClick.AddListener(() => SelectUpgrade(option2Button.GetComponentInChildren<TextMeshProUGUI>().text));
        option3Button.onClick.AddListener(() => SelectUpgrade(option3Button.GetComponentInChildren<TextMeshProUGUI>().text));
    }

    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void TriggerLevelUp()
    {
        isPaused = true;
        levelUpPanel.SetActive(true);

        List<string> options = GenerateUpgradeOptions();

        if (options.Count > 0)
            option1Button.GetComponentInChildren<TextMeshProUGUI>().text = options[0];
        if (options.Count > 1)
            option2Button.GetComponentInChildren<TextMeshProUGUI>().text = options[1];
        if (options.Count > 2)
            option3Button.GetComponentInChildren<TextMeshProUGUI>().text = options[2];
    }

    List<string> GenerateUpgradeOptions()
    {
        List<string> availableUpgrades = new List<string>();

        // Check which abilities the player has and add corresponding upgrades
        if (playerAbilities.HasAbility("CameraZoom"))
        {
            availableUpgrades.Add("Upgrade Camera Zoom");
        }

        if (playerAbilities.HasAbility("HealthBoost"))
        {
            availableUpgrades.Add("Upgrade Health");
        }

        if (playerAbilities.HasAbility("AttackBoost"))
        {
            availableUpgrades.Add("Upgrade Attack Power");
        }

        // Add new abilities if not acquired yet
        if (!playerAbilities.HasAbility("CameraZoom"))
        {
            availableUpgrades.Add("Acquire Camera Zoom");
        }
        if (!playerAbilities.HasAbility("HealthBoost"))
        {
            availableUpgrades.Add("Acquire Health Boost");
        }
        if (!playerAbilities.HasAbility("AttackBoost"))
        {
            availableUpgrades.Add("Acquire Attack Boost");
        }

        return availableUpgrades;
    }

    void SelectUpgrade(string selectedUpgrade)
    {
        switch (selectedUpgrade)
        {
            case "Upgrade Camera Zoom":
                FindObjectOfType<CameraController>().UpgradeCameraZoom();
                break;
            case "Upgrade Health":
                // Add health upgrade logic here
                break;
            case "Upgrade Attack Power":
                // Add attack power upgrade logic here
                break;
            case "Acquire Camera Zoom":
                playerAbilities.AddAbility("CameraZoom");
                break;
            case "Acquire Health Boost":
                playerAbilities.AddAbility("HealthBoost");
                break;
            case "Acquire Attack Boost":
                playerAbilities.AddAbility("AttackBoost");
                break;
        }

        levelUpPanel.SetActive(false);
        isPaused = false;
    }
}
