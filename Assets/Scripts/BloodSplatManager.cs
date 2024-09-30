using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BloodSplatManager : MonoBehaviour
{
    public GameObject[] bloodSplatPrefabs;    // Array to hold all blood splat prefabs
    public RectTransform uiCanvasTransform;   // Reference to the existing UI Canvas RectTransform
    public int splatsToShow = 4;              // Number of splats to show each time player is hit
    public float fadeDuration = 2.0f;         // Duration to fade out the blood splats

    // Define the canvas size (1920 x 1080)
    private const float canvasWidth = 1920f;
    private const float canvasHeight = 1080f;

    void Awake()
    {
        // Automatically assign the RectTransform if it's not set in the Inspector
        if (uiCanvasTransform == null)
        {
            uiCanvasTransform = GetComponent<RectTransform>();
        }
    }

    public void ShowBloodSplats()
    {
        List<GameObject> selectedSplats = new List<GameObject>();

        // Randomly select unique splats from the available prefabs
        for (int i = 0; i < splatsToShow; i++)
        {
            int randomIndex = Random.Range(0, bloodSplatPrefabs.Length);
            GameObject selectedSplat = bloodSplatPrefabs[randomIndex];
            selectedSplats.Add(selectedSplat);
        }

        // For each selected blood splat prefab, assign it a random position within the canvas
        foreach (GameObject splatPrefab in selectedSplats)
        {
            // Instantiate the splat as a child of the UI Canvas
            GameObject splatInstance = Instantiate(splatPrefab, uiCanvasTransform);

            RectTransform splatRect = splatInstance.GetComponent<RectTransform>();
            if (splatRect == null)
            {
                Debug.LogError("Blood splat instance is missing RectTransform!");
                return;
            }

            // Generate a random position within the canvas bounds
            Vector2 randomPosition = GetRandomPositionWithinCanvas(uiCanvasTransform, splatRect);

            // Set the anchored position for the blood splat
            splatRect.anchoredPosition = randomPosition;

            // Ensure the blood splat is scaled properly
            splatRect.localScale = Vector3.one;

            // Optional: Start the fade-out coroutine for the blood splat
            Image splatImage = splatInstance.GetComponent<Image>();
            if (splatImage != null)
            {
                StartCoroutine(FadeOutSplat(splatImage));
            }
        }
    }

    // Generate a random position within the canvas bounds while considering the blood splat size
    private Vector2 GetRandomPositionWithinCanvas(RectTransform canvasRect, RectTransform splatRect)
    {
        // Get half the width and height of the splat to prevent it from overflowing the canvas bounds
        float halfSplatWidth = splatRect.rect.width / 2;
        float halfSplatHeight = splatRect.rect.height / 2;

        // Calculate the random X and Y positions within the canvas bounds
        float randomX = Random.Range(-canvasWidth / 2 + halfSplatWidth, canvasWidth / 2 - halfSplatWidth);
        float randomY = Random.Range(-canvasHeight / 2 + halfSplatHeight, canvasHeight / 2 - halfSplatHeight);

        return new Vector2(randomX, randomY);
    }

    public IEnumerator FadeOutSplat(Image splatImage)
    {
        float startAlpha = splatImage.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            Color newColor = splatImage.color;
            newColor.a = Mathf.Lerp(startAlpha, 0, time / fadeDuration);  // Gradually fade out the alpha
            splatImage.color = newColor;
            yield return null;
        }

        Destroy(splatImage.gameObject);  // Remove the splat after fading
    }
}
