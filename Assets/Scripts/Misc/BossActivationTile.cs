using UnityEngine;

public class BossActivationTile : MonoBehaviour
{
    public BossMovement boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("Activating Boss!");
            if (boss != null) boss.ActivateBoss();
        }
    }
}
