using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float moveSpeed = 7;
    public float attackRange = 3;
    private Transform target;
    public float health = 1200f; // Starting health value

    public float damage = 50;

    public float hitWaitTime = 3f;
    private float hitCounter;
    private bool active = false;
    UnityEngine.AI.NavMeshAgent agent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        moveSpeed = Random.Range(0.7f, 1.4f);
        if (attackRange == 0f) attackRange = 5.0f;
        active = false;
    }

    // Update is called once per frame
    void Update() {
        if (active == true) {
            agent.SetDestination(target.position);
        } else {
            agent.SetDestination(theRigidbody.position);
        }

        if(hitCounter > 0f) {
            hitCounter -= Time.deltaTime;
        }
    }

    public void ActivateBoss() {
        active = true;
    }

    public bool isActive() {
        return active;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        float _playerDistance = Vector2.Distance(target.position, theRigidbody.position);

        if(PlayerHealth.instance.tag == "Player" && hitCounter <= 0f 
            && _playerDistance <= attackRange) {
                Debug.Log("Boss attacking player with strength: " + damage);
                PlayerHealth.instance.TakeDamage(damage);
                hitCounter = hitWaitTime;
        }    
    }

    public void TakeDamage(float damage) {
        Debug.Log("Boss TakeDamage called!");
        if (active == true) {
            Debug.Log("Boss active, taking damage!");
            health -= damage;
            if (health <= 0)
            {
                OnDeath();
            }
        } else {
            Debug.Log("Boss inactive!");
        }
    }

    private void OnDeath() {
        Destroy(gameObject);
    }
}
