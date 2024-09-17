using UnityEngine;

public class ShowControls : MonoBehaviour
{
    public GameObject controlsPanel; // Drag the Panel GameObject here in the inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlsPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        // Show the controls pop-up when the player presses 'H'
        if (Input.GetKeyDown(KeyCode.H))
        {
            controlsPanel.SetActive(!controlsPanel.activeSelf);
        }
    }
    // Method to close the panel (for the Close button)
    public void ClosePanel()
    {
        controlsPanel.SetActive(false);
    }
}
