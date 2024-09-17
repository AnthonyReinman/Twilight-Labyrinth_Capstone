using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{

    public GameObject wall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("Activating Checkpoint!");
            wall.SetActive(true);
        }
    }
}
