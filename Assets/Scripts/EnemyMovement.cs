using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float moveSpeed;
    public float attackRange;
    private Transform target;

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // target = FindAnyObjectByType<PlayerMovement>().transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        moveSpeed = Random.Range(0.7f, 1.4f);
        if (attackRange == 0f) attackRange = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // theRigidbody.velocity = (target.position - transform.position).normalized * moveSpeed;
        agent.SetDestination(target.position);

        if(hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float _playerDistance = Vector2.Distance(target.position, theRigidbody.position);

        if(PlayerHealth.instance.tag == "Player" && hitCounter <= 0f && _playerDistance <= attackRange)
        {
            Debug.Log("Enemy attacking player with strength: " + damage);
            Debug.Log("_playerDistance: " + _playerDistance);
            PlayerHealth.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }    
    }
}
