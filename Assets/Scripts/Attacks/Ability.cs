using UnityEngine;

[System.Serializable]
public class Ability
{
    public string name;
    public float damage;
    public float range;
    public float cooldown;
    private float lastUsedTime;

    public Ability(string name, float damage, float range, float cooldown)
    {
        this.name = name;
        this.damage = damage;
        this.range = range;
        this.cooldown = cooldown;
    }

    public bool CanUse()
    {
        return Time.time >= lastUsedTime + cooldown;
    }

    public void Use()
    {
        lastUsedTime = Time.time;
    }
}
