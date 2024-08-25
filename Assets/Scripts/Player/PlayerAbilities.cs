using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private List<string> acquiredAbilities = new List<string>();

    [System.Serializable]
    public class Ability
    {
        public string abilityName;
        public GameObject abilityPrefab;
    }

    public List<Ability> availableAbilities = new List<Ability>();

    public void AddAbility(string abilityName)
{
    if (!acquiredAbilities.Contains(abilityName))
    {
        acquiredAbilities.Add(abilityName);

        Ability abilityToActivate = availableAbilities.Find(ability => ability.abilityName == abilityName);
        if (abilityToActivate != null)
        {
            GameObject abilityInstance = Instantiate(abilityToActivate.abilityPrefab, transform.position, Quaternion.identity, transform);
            abilityInstance.SetActive(true);
            Debug.Log(abilityName + " ability acquired and instantiated.");
        }
        else
        {
            Debug.LogWarning("Ability " + abilityName + " not found in available abilities.");
        }
    }
}

    public bool HasAbility(string abilityName)
    {
        return acquiredAbilities.Contains(abilityName);
    }

    public List<string> GetAcquiredAbilities()
    {
        return acquiredAbilities;
    }
}
