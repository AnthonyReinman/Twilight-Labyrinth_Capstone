using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public Transform firePoint; // The point from where the projectile will be fired
    public GameObject basicProjectile; // The projectile to be fired
    public float attackInterval = 1f; // Time interval between attacks

    private float attackTimer = 0f;

    void Start()
    {
        Debug.Log("PlayerAttackManager started");
    }

    void Update()
    {
        // Update the attack timer
        attackTimer += Time.deltaTime;

            // Stop attacks if GameOver
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        // Check if the attack timer has reached the attack interval
        if (attackTimer >= attackInterval)
        {
            // Reset the attack timer
            attackTimer = 0f;

            // Perform the attack
            Attack();
        }

        // Aim the fire point towards the mouse cursor
        Aim();
    }

    public void Aim()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Rotate the fire point to face the mouse cursor
        firePoint.up = direction;
    }

    public void Attack()
    {
        // Instantiate the projectile at the fire point's position and rotation
        Instantiate(basicProjectile, firePoint.position, firePoint.rotation);
        Debug.Log("Attack called, instantiating projectile.");
    }
}
