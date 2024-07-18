using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Ensure a reasonable default value

    private Rigidbody2D _rigidbody;

     void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D not found on Player");
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;
        
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();

        _rigidbody.velocity = moveInput * moveSpeed;
    }
}
