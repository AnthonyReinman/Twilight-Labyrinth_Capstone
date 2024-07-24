using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float moveSpeed;
    private Transform target;

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindAnyObjectByType<PlayerMovement>().transform;

        moveSpeed = Random.Range(0.7f, 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        theRigidbody.velocity = (target.position - transform.position).normalized * moveSpeed;

        if(hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(PlayerHealth.instance.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealth.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }    
    }
}
