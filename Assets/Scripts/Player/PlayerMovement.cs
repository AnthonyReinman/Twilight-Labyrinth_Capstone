using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Ensure a reasonable default value

    private Rigidbody2D _rigidbody;
    private bool isFacingRight = true;

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

        if (Input.GetAxisRaw("Horizontal") >= 0) {
            isFacingRight = true;
        } else {
            isFacingRight = false;
        }

        CheckFlip();
        _rigidbody.velocity = moveInput * moveSpeed;
    }

    private void CheckFlip() {
        if (transform.localEulerAngles.y != 180 && !isFacingRight) {
            transform.Rotate(0f, 180f, 0f);
        } else if(transform.localEulerAngles.y != 0 && isFacingRight) {
            transform.Rotate(0f, -180f, 0f);
        }
    }
}
