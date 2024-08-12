using UnityEngine;

public class CameraZoomAbility : Ability
{
    public Camera mainCamera;
    public float defaultZoom = 5f;
    public float maxZoomOut = 10f;
    public float zoomStep = 1f;

    private float currentZoom;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // This should assign the Main Camera
        }

        if (mainCamera != null)
        {
            currentZoom = defaultZoom;
            mainCamera.orthographicSize = currentZoom; // Ensure the camera is active and correctly set up
        }
        else
        {
            Debug.LogError("Main Camera is not assigned or found!");
        }

        SetActive(isActive); // Initialize the active state
    }

    public override void Activate()
    {
        // Activation logic if needed
    }

    public override void Upgrade()
    {
        if (level < maxLevel && currentZoom < maxZoomOut)
        {
            level++;
            currentZoom += zoomStep;
            if (mainCamera != null)
            {
                mainCamera.orthographicSize = currentZoom;
            }
        }
    }
}