using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> availableAbilities;
    private List<Ability> acquiredAbilities = new List<Ability>();

    void Start()
    {
        // Test the CameraZoomAbility by upgrading it once at the start
        UpgradeAbility("Camera Zoom");

        foreach (var ability in availableAbilities)
        {
            ability.SetActive(false); // Disable all abilities at the start
        }
        EventManager.Instance.OnLevelUp += HandleLevelUp; // Subscribe to level-up events
    }

    void Update()
    {
        // Optional: Press the "U" key to upgrade the ability during play
        if (Input.GetKeyDown(KeyCode.U))
        {
            UpgradeAbility("Camera Zoom");
        }
    }

    void OnDestroy()
    {
        EventManager.Instance.OnLevelUp -= HandleLevelUp; // Unsubscribe from level-up events
    }

    public void AcquireAbility(string abilityName)
    {
        Ability ability = availableAbilities.Find(a => a.abilityName == abilityName);
        if (ability != null && !acquiredAbilities.Contains(ability))
        {
            ability.SetActive(true); // Activate the ability
            acquiredAbilities.Add(ability); // Add to acquired abilities
        }
    }

    public void UpgradeAbility(string abilityName)
    {
        Ability ability = acquiredAbilities.Find(a => a.abilityName == abilityName);
        if (ability != null)
        {
            ability.Upgrade(); // Upgrade only if the ability is acquired
        }
    }

    public void HandleLevelUp(int level)
    {
        // Logic to offer new abilities or upgrades based on whether all abilities are acquired
        if (acquiredAbilities.Count < availableAbilities.Count)
        {
            OfferNewAbilityChoice();
        }
        else
        {
            OfferUpgradeChoice();
        }
    }

    void OfferNewAbilityChoice()
    {
        // Offer a new ability based on logic
        // Example: Choose randomly from non-acquired abilities
        List<Ability> choices = GetRandomAbilities(3);
        // Implement UI to show these choices to the player
    }

    void OfferUpgradeChoice()
    {
        // Offer upgrades for acquired abilities
        List<Ability> choices = GetRandomUpgrades(3);
        // Implement UI to show these upgrade choices to the player
    }

    List<Ability> GetRandomAbilities(int count)
    {
        List<Ability> choices = new List<Ability>();
        List<Ability> nonAcquired = availableAbilities.FindAll(a => !acquiredAbilities.Contains(a));

        while (choices.Count < count && nonAcquired.Count > 0)
        {
            Ability choice = nonAcquired[Random.Range(0, nonAcquired.Count)];
            choices.Add(choice);
            nonAcquired.Remove(choice);
        }

        // Apply luck influence if needed
        return choices;
    }

    List<Ability> GetRandomUpgrades(int count)
    {
        List<Ability> choices = new List<Ability>();

        while (choices.Count < count && acquiredAbilities.Count > 0)
        {
            Ability choice = acquiredAbilities[Random.Range(0, acquiredAbilities.Count)];
            choices.Add(choice);
        }

        // Apply luck influence if needed
        return choices;
    }
}