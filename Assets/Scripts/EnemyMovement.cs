using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float moveSpeed;
    private Transform target;

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;

    public float health = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = PlayerHealth.instance.transform;
        moveSpeed = Random.Range(moveSpeed * 0.7f, moveSpeed * 1.4f); // mobs random speed movement
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            theRigidbody.velocity = (target.position - transform.position).normalized * moveSpeed;
        }

        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }

        /* if(PlayerHealth.instance.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealth.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        } */
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
