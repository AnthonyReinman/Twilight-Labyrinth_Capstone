using UnityEngine;

public class EndLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Level Complete!");
        }
    }

    void OnTriggerStay2D(Collider2D other) { }

    void OnTriggerExit2D(Collider2D other) { }
}
