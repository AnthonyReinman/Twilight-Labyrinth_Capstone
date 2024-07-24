using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 20f; // Set the damage dealt by the projectile

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collided with an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Get the EnemyController component from the collided object
            EnemyController enemy = collision.GetComponent<EnemyController>();

            // Deal damage to the enemy
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Destroy the projectile on collision
            Destroy(gameObject);
        }
    }
}
