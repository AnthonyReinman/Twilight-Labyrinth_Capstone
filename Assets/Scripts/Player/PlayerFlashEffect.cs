using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerFlashEffect : MonoBehaviour
{
    [SerializeField]
    private Image flashImage;

    public float flashDuration = 0.2f; // How long the flash lasts
    public float flashAlpha = 0.5f;   // Max opacity during the flash

    private Color flashColor;         // Color used for flashing
    private bool isFlashing = false;  // To track if we're currently flashing

    void Start()
    {
        if (flashImage != null)
        {
            flashColor = flashImage.color;
            flashColor.a = 0; // Start with fully transparent
            flashImage.color = flashColor;
            flashImage.gameObject.SetActive(false); // Hide the image initially
        }
    }

    public void FlashScreen()
{
    Debug.Log("FlashScreen called"); // Add this to verify it's being triggered
    if (!isFlashing)
    {
        flashColor.a = flashAlpha; // Ensure the alpha is set before flashing
        StartCoroutine(FlashRoutine());
    }
}

   public IEnumerator FlashRoutine()
{
    Debug.Log("FlashRoutine started");
    isFlashing = true;
    flashImage.gameObject.SetActive(true);

    float elapsedTime = 0f;
    while (elapsedTime < flashDuration * 5) // Increase the duration temporarily for testing
    {
        elapsedTime += Time.deltaTime;
        flashColor.a = Mathf.Lerp(flashAlpha, 0, elapsedTime / (flashDuration * 5)); // Slow fade out for testing
        flashImage.color = flashColor;
        yield return null;
    }

    flashImage.gameObject.SetActive(false);
    isFlashing = false;
}
}
