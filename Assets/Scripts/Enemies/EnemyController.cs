using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float health = 100f; // Starting health value
    public float movementSpeed = 5f; // Speed enemy will move through the world
    public float attackRange = 1f; // Max distance you can be from player to attack
    public float attackStrength = 2f; // Damage that will be done to player upon successful attack
    public float attackCooldown = 1f; // Time in seconds between attacks
    public Transform playerObject; // Player transform object

    private Rigidbody2D _body; // Enemy rigidbody, will get from object
    private Vector2 _playerDirection; // Direction player is relative to player, used for tracking and following player
    private float _playerDistance;
    private float nextAttackTime; // Time when the enemy can attack next
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        if (_body == null)
        {
            Debug.LogError("Rigidbody2D not found on Enemy");
        }


        if (!playerObject)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerObject = player.transform;
            }
            else
            {
                Debug.LogError("Enemy failed to find player!");
            }
        }
    }

    void Update()
    {
        // if (GameManager.Instance.isGameOver) return;

        if (playerObject != null)
        {
            Vector2 tmpDirection = (Vector2)playerObject.position - _body.position;
            tmpDirection.Normalize();
            _playerDirection = tmpDirection;
            agent.SetDestination(playerObject.position);

            _playerDistance = Vector2.Distance(playerObject.position, _body.position);

            if (_playerDistance <= attackRange && Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackCooldown; // Set the next attack time
            }
        }
    }

    private void FixedUpdate()
    {
        if (_body != null && _playerDirection != null)
        {
            // _body.MovePosition((Vector2)_body.position + (_playerDirection * movementSpeed * Time.fixedDeltaTime));
        }
    }

    private void AttackPlayer()
    {
        HealthSystem playerHealthSystem = playerObject.GetComponent<HealthSystem>();
        if (playerHealthSystem != null)
        {
            Debug.Log("Enemy attacking player with strength: " + attackStrength);
            // playerHealthSystem.TakeDamage(attackStrength);
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        Debug.Log(" died at position: " + transform.position);

        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        // Log death message
        Debug.Log("Enemy died at position: " + transform.position);

        // Spawn XP
        ExperienceLevelConotroller.instance.SpawnExp(transform.position);

        // Optionally: Add additional death logic here

        // Destroy the enemy
        Destroy(gameObject);
    }
}