using UnityEngine;

public class AuraAbility : MonoBehaviour
{
    public float damage = 10f;
    public float auraRadius = 2f;
    private CircleCollider2D auraCollider;

    void Start()
    {
        // Get the CircleCollider2D component
        auraCollider = GetComponent<CircleCollider2D>();
        if (auraCollider != null)
        {
            auraCollider.isTrigger = true;  // Ensure it is a trigger collider
            auraCollider.radius = auraRadius;
        }
        else
        {
            Debug.LogError("CircleCollider2D not found on AuraAbility prefab.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the aura: " + other.name); // Log the name of the object that entered the aura

        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Debug.Log("Enemy detected: " + enemy.name + ". Applying damage: " + damage);
            enemy.TakeDamage(damage);
        }
        else
        {
            Debug.Log("No EnemyController found on this object.");
        }
    }

    public void UpgradeAura(float extraDamage, float extraRadius)
    {
        // Increase damage and radius
        damage += extraDamage;
        auraRadius += extraRadius;
        auraCollider.radius = auraRadius; // Update collider radius
    }
}
