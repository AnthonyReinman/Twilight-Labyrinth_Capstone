using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerFlashEffect : MonoBehaviour
{
    [SerializeField]
    private Image flashImage;
    public Sprite flashSprite;

    public float flashDuration = 0.2f; // How long the flash lasts
    public float flashAlpha = 0.5f;   // Max opacity during the flash

    private Color flashColor;         // Color used for flashing
    private bool isFlashing = false;  // To track if we're currently flashing

    void Start()
    {
        if (flashImage != null)
        {
            if (flashSprite != null)
            {
                flashImage.sprite = flashSprite;  // Assign the sprite to the Image
            }
            flashColor = flashImage.color;
            flashColor.a = 0; // Start with fully transparent
            flashImage.color = flashColor;
            flashImage.gameObject.SetActive(false); // Hide the image initially
        }
        else
        {
            Debug.LogError("flashImage is not assigned in the Inspector!");
        }
    }

    public void FlashScreen()
{
    Debug.Log("FlashScreen called"); 
    if (!isFlashing && flashImage != null)
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
    while (elapsedTime < flashDuration * 5) 
    {
        elapsedTime += Time.deltaTime;
        flashColor.a = Mathf.Lerp(flashAlpha, 0, elapsedTime / (flashDuration * 5));
        flashImage.color = flashColor;
        yield return null;
    }

    flashImage.gameObject.SetActive(false);
    isFlashing = false;
}
}
