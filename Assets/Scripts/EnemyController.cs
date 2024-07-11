using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Pubic Members
    public float health = 100f; // Starting health value
    public float movementSpeed = 5f; // Speed enemy will move through the world
    public float attackRange = 10f; // Max distance you can be from player to attack
    public float attackStrength = 2f; // Damage that will be done to player upon successful attack
    public Transform playerObject; // Player transform object

    // Private Members
    private Rigidbody2D _body; // Enemy rigidbody, will get from object
    private Vector2 _playerDirection; // Direction player is relative to player, used for tracking and following player
    private float _playerDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        if (!playerObject) {
            playerObject = GameObject.FindGameObjectWithTag("Player").transform;
            if (!playerObject) Debug.LogError("Enemy failed to find player!");
        }
    }

    // Update is called once per frame
    void Update() {
        if (playerObject != null) {
            // Update Player Direction
            Vector2 tmpDirection = (Vector2)playerObject.position - _body.position;
            tmpDirection.Normalize();
            _playerDirection = tmpDirection;

            // Get distance to player
            _playerDistance = Vector2.Distance(playerObject.position, _body.position);

            // Attack Player if close enough
            if (_playerDistance <= attackRange) {
                AttackPlayer();
            }
        }
    }

    // Fixed Update is where updates to the RigidBody should go
    private void FixedUpdate() {
        if (_body != null && _playerDirection != null) {
            _body.MovePosition((Vector2)_body.position + (_playerDirection * movementSpeed * Time.fixedDeltaTime));
        }
    }

    private void AttackPlayer() {
        // -- TODO Attacking Player Implementation
    }

    public void TakeDamage(float damage) {
        health = health - damage;
        if (health <= 0) {
            OnDeath();
        }
    }

    private void OnDeath() {
        // -- TODO Full Enemy Death Implementation

        // TODO Play Death Animation

        // Destory Game Object
        Destroy(gameObject);

        //TODO Drop Loot/Transfer Loot To Player
    }

    // Private Accessors

    public Rigidbody2D GetBody() { return _body; }
    public Vector2 GetPlayerDirection() { return _playerDirection; }
    public float GetPlayerDistance() { return _playerDistance; }
}
