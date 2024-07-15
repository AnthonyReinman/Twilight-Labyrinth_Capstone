using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBarFill; //health bar fill image

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        if (GameManager.Instance.isGameOver) return;

        Debug.Log("TakeDamage called with amount: " + amount);
        currentHealth -= amount;
        Debug.Log("Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    private void Die()
    {
        Debug.Log("Player died!");
        GameManager.Instance.GameOver();
    }

    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
