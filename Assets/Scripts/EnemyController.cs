using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 100f;
    public float movementSpeed = 5f;
    public float attackRange = 1f;
    public float attackStrength = 10f;
    public Transform playerObject;

    private Rigidbody2D _body;
    private Vector2 _playerDirection;
    private float _playerDistance;
    private float attackCooldown = 1f; // Time between attacks
    private float nextAttackTime = 0f;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        if (!playerObject)
        {
            playerObject = GameObject.FindGameObjectWithTag("Player").transform;
            if (!playerObject) Debug.LogError("Enemy failed to find player!");
        }
    }

    void Update()
    {
        if (playerObject != null)
        {
            Vector2 tmpDirection = (Vector2)playerObject.position - _body.position;
            tmpDirection.Normalize();
            _playerDirection = tmpDirection;

            _playerDistance = Vector2.Distance(playerObject.position, _body.position);

            if (_playerDistance <= attackRange && Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_body != null && _playerDirection != null)
        {
            _body.MovePosition((Vector2)_body.position + (_playerDirection * movementSpeed * Time.fixedDeltaTime));
        }
    }

    private void AttackPlayer()
    {
        PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.TakeDamage(attackStrength);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
}
