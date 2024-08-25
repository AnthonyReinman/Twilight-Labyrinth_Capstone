using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private List<string> acquiredAbilities = new List<string>();

    public void AddAbility(string abilityName)
    {
        if (!acquiredAbilities.Contains(abilityName))
        {
            acquiredAbilities.Add(abilityName);
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
