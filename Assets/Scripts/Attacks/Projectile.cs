using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision with enemies or other objects
        Destroy(gameObject);
    }
}
