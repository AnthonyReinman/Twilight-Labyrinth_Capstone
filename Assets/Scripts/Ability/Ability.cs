using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string abilityName;
    public int level = 1;
    public int maxLevel = 5;
    public bool isActive = false; // Tracks if the ability is active

    public abstract void Activate();
    public abstract void Upgrade();

    public void SetActive(bool active)
    {
        isActive = active;
        gameObject.SetActive(active);
    }
}
