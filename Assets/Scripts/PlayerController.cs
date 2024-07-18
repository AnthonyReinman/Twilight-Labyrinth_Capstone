using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Public Members
    public float movementSpeed = 5f;
    public float maxHealth = 100f;
    public float currentHealth;
    public float maxXP = 100f;
    public float currentXP;
    public float lifestealPercentage = 0.1f;
    public Image healthBar;
    public Image xpBar;

    // Input keys
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode ultimateAbilityKey = KeyCode.Space;

    // Private Members
    private Rigidbody2D _rb;
    private Vector2 _movement;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        currentXP = 0;
        UpdateHealthBar();
        UpdateXPBar();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle Movement Input
        _movement = Vector2.zero;

        if (Input.GetKey(moveUpKey))
        {
            _movement.y += 1;
        }
        if (Input.GetKey(moveDownKey))
        {
            _movement.y -= 1;
        }
        if (Input.GetKey(moveLeftKey))
        {
            _movement.x -= 1;
        }
        if (Input.GetKey(moveRightKey))
        {
            _movement.x += 1;
        }

        // Normalize movement vector to ensure consistent speed
        _movement.Normalize();

        // Trigger ultimate ability
        if (Input.GetKeyDown(ultimateAbilityKey))
        {
            UltimateAbility();
        }

        // Update UI elements
        UpdateHealthBar();
        UpdateXPBar();
    }

    // FixedUpdate is called at a fixed interval and is used for physics updates
    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D
        _rb.MovePosition(_rb.position + _movement * movementSpeed * Time.fixedDeltaTime);
    }

    // Function to take damage
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthBar();
    }

    // Function to heal the player
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    // Function to add XP
    public void AddXP(float amount)
    {
        currentXP += amount;
        if (currentXP >= maxXP)
        {
            LevelUp();
        }
        UpdateXPBar();
    }

    // Function to handle leveling up
    private void LevelUp()
    {
        currentXP -= maxXP;
        // Handle level up (increase stats, choose upgrades)
    }

    // Function to handle player death
    private void Die()
    {
        // Handle player death (respawn, game over)
        Debug.Log("Player died!");
    }

    // Function to update the health bar UI
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    // Function to update the XP bar UI
    private void UpdateXPBar()
    {
        xpBar.fillAmount = currentXP / maxXP;
    }

    // Function to trigger the ultimate ability
    private void UltimateAbility()
    {
        // Implement ultimate ability logic
        Debug.Log("Ultimate ability triggered!");
    }

    // Public method to change key bindings
    public void SetKeyBindings(KeyCode up, KeyCode down, KeyCode left, KeyCode right, KeyCode ultimate)
    {
        moveUpKey = up;
        moveDownKey = down;
        moveLeftKey = left;
        moveRightKey = right;
        ultimateAbilityKey = ultimate;
    }
}
