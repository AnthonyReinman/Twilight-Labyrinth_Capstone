using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    public Camera mainCamera; // Reference to the main camera
    public float baseSize = 5f; // Base orthographic size
    public float sizeIncrement = 1f; // Amount to increase the orthographic size
    public float maxSize = 10f; // Maximum orthographic size

    void Start()
    {
        target = FindAnyObjectByType<PlayerMovement>().transform;
        mainCamera.orthographicSize = baseSize; // Set the initial orthographic size
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    public void UpgradeCameraZoom()
    {
        if (mainCamera.orthographicSize < maxSize)
        {
            mainCamera.orthographicSize = Mathf.Min(mainCamera.orthographicSize + sizeIncrement, maxSize);
        }
    }

    // This method is called when the script is loaded or when a value is changed in the Inspector
    void OnValidate()
    {
        if (mainCamera != null)
        {
            mainCamera.orthographicSize = baseSize;
        }
    }
}
