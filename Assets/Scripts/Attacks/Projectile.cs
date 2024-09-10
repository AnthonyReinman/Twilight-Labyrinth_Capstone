using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 20f; // Set the damage dealt by the projectile

    void Start()
    {
        float attackDamageMod = PlayerPrefs.GetFloat("attackDamageBuff");
        if (attackDamageMod != null && attackDamageMod > 0) {
            Debug.Log("Applying attack damage buff [" + attackDamageMod + "]!");
            damage += attackDamageMod;
        }
    }

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
        // Check if the projectile collided with an enemy
        else if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            // Get the EnemyController component from the collided object
            EnemyController enemy = collision.GetComponent<EnemyController>();

            // Deal damage to the enemy
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            } else {
                BossMovement boss = collision.GetComponent<BossMovement>();
                if (boss != null) {
                    boss.TakeDamage(damage);
                }
            }

            // Destroy the projectile on collision
            Destroy(gameObject);
        }
    }
}
