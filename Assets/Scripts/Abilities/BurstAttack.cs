using UnityEngine;

public class BurstAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile to be fired in the burst attack
    public int projectileCount = 8; // Number of projectiles in the burst attack
    public float spreadAngle = 360f; // Total spread angle for the burst attack
    public Transform firePoint; // The point from where the projectiles will be fired

    public void ExecuteBurstAttack()
    {
        float angleStep = spreadAngle / projectileCount;
        float angle = 0f;

        for (int i = 0; i < projectileCount; i++)
        {
            // Calculate the direction for each projectile in the burst
            float projectileDirX = firePoint.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float projectileDirY = firePoint.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 projectileMoveVector = new Vector3(projectileDirX, projectileDirY, 0);
            Vector2 projectileDirection = (projectileMoveVector - firePoint.position).normalized;

            // Instantiate and shoot the burst projectile
            GameObject tempProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = tempProjectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = projectileDirection * tempProjectile.GetComponent<Projectile>().speed;
            }

            angle += angleStep;
        }

        Debug.Log("Burst attack executed.");
    }
}
