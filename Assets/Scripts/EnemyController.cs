using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    // Pubic Members
    public LayerMask wallLayer;
    public float health = 100f; // Starting health value
    public float movementSpeed = 5f; // Speed enemy will move through the world
    public float attackRange = 10f; // Max distance you can be from player to attack
    public float attackStrength = 2f; // Damage that will be done to player upon successful attack
    // public int wallDetectDist = 2;
    // public float wallAvoidDist = 5f;
    public Transform playerObject; // Player transform object

    // Private Members
    private Rigidbody2D _body; // Enemy rigidbody, will get from object
    private Vector2 _playerDirection; // Direction player is relative to player, used for tracking and following player
    private float _playerDistance;
    private Vector2 nextMove;
    // private bool isStuck = false;
    // public int stuckCheckInterval = (60 * 30);
    // private int stuckCheckCounter = (60 * 30) + 1;
    // private Vector2 lastPos;
    // private Vector2 avoidanceDirection;
    // private bool avoidingWall = false;
    // public float wallAvoidDist = 5f;
    // private float avoidTime = 100f;
    // private float avoidTimer = 0f;

    // public float wallAvoidDist = 1f;
    // public float avoidTime = 5f;
    // public float avoidTimer = 0f;
    // public float waitTime = 2f;
    // private float cooldownTimer = 0f;
    // private Vector2 avoidanceDirection;
    // private bool avoidingWall = false;

    // public float wallDetctDist = 1f;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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
            agent.SetDestination(playerObject.position);

            // Debug.DrawLine(_body.position, _body.position + _playerDirection * 2, Color.yellow);

            // RaycastHit2D hit = Physics2D.Raycast(_body.position, _playerDirection, 2, LayerMask.GetMask("Wall"));
            // if (hit.collider != null) {
            //     Vector2 avoidanceDirection = Vector2.Perpendicular(hit.normal) * 1f;
            //     nextMove = (_playerDirection + avoidanceDirection).normalized;
            // } else {
            //     nextMove = _playerDirection;
            // }

            // RaycastHit2D hit;

            // if (avoidingWall) {
            //     hit =  Physics2D.Raycast(_body.position, avoidanceDirection, wallAvoidDist, LayerMask.GetMask("Wall"));
            //     Debug.DrawLine(_body.position, _body.position + avoidanceDirection * wallAvoidDist, Color.yellow);
            // } else {
            //     hit = Physics2D.Raycast(_body.position, _playerDirection, 2, LayerMask.GetMask("Wall"));
            //     Debug.DrawLine(_body.position, _body.position + _playerDirection * 2, Color.yellow);
            // }

            // if (hit.collider != null) {
            //     if (!avoidingWall) {
            //         avoidanceDirection = (Random.value > 0.5f ? Vector2.Perpendicular(_playerDirection) : -Vector2.Perpendicular(_playerDirection)).normalized;
            //         avoidingWall = true;
            //         avoidTimer = avoidTime;
            //     }
            //     nextMove = (_playerDirection + avoidanceDirection * wallAvoidDist).normalized;
            //     avoidTimer -= Time.deltaTime;
            //     if (avoidTimer <= 0) {
            //         avoidingWall = false;
            //     }
            // } else {
            //     nextMove = _playerDirection;
            //     avoidingWall = false;
            // }

            // nextMove = _playerDirection;
            // RaycastHit2D rcHit = Physics2D.Raycast(transform.position, nextMove, wallDetctDist, wallLayer);
            // Debug.DrawLine(_body.position, _body.position + nextMove * wallDetctDist, Color.yellow);
            // if (rcHit.collider != null) {
            //     Vector2 wallNml = rcHit.normal;
            //     Vector2 avoidDirc = Vector2.Perpendicular(wallNml).normalized;
            //     nextMove = avoidDirc;
            // }


            // Get distance to player
            _playerDistance = Vector2.Distance(playerObject.position, _body.position);

            // Attack Player if close enough
            if (_playerDistance <= attackRange) {
                AttackPlayer();
            }

            // stuckCheckCounter++;
            // if (stuckCheckCounter >= stuckCheckInterval) {
            //     if (Vector2.Distance(_body.position, lastPos) < 0.05f) {
            //         Debug.Log("Enemy is stuck, backtracking");
            //         isStuck = true;
            //     } else {
            //         Debug.Log("Enemy is not stuck!");
            //         isStuck = false;
            //     }
            //     lastPos = _body.position;
            //     stuckCheckCounter = 0;
            // }
        }
    }

    // Fixed Update is where updates to the RigidBody should go
    private void FixedUpdate() {
        if (_body != null && _playerDirection != null) {
            // _body.MovePosition((Vector2)_body.position + (nextMove * movementSpeed * Time.fixedDeltaTime));
        }

        // if (agent != null && playerObject != null) {
        //     agent.SetDestination(playerObject.position);
        // }
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
