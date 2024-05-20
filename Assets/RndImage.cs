using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RndImage : MonoBehaviour
{
    public List<Sprite> images; // List to hold the images
    public Camera mainCamera; // Reference to the main camera
    public float spawnDistance = 4f; // Distance to spawn the image from the camera
    public float fadeDuration = 6f; // Duration for the alpha fade

    private GameObject imageObject; // GameObject to hold the Image component
    private Image imageComponent; // Image component to display the sprite

    void Start()
    {
        if (images == null || images.Count == 0)
        {
            Debug.LogError("Images list is not assigned or empty.");
            return;
        }
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Create a new GameObject with a Canvas and Image component
        imageObject = new GameObject("RandomImage");
        Canvas canvas = imageObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        CanvasScaler canvasScaler = imageObject.AddComponent<CanvasScaler>();
        canvasScaler.dynamicPixelsPerUnit = 10;
        imageObject.AddComponent<GraphicRaycaster>();

        GameObject imageChild = new GameObject("Image");
        imageChild.transform.SetParent(imageObject.transform);
        imageComponent = imageChild.AddComponent<Image>();

        RectTransform rectTransform = imageComponent.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(1, 1); // Set size of the image
        rectTransform.anchoredPosition = Vector2.zero; // Center the image in the canvas

        // Set the position of the Canvas in world space 4 meters in front of the camera
        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance;
        imageObject.transform.position = spawnPosition;
        imageObject.transform.rotation = mainCamera.transform.rotation;

        // Start the process of displaying a random image
        StartCoroutine(DisplayRandomImage());
    }

    IEnumerator DisplayRandomImage()
    {
        // Select a random image from the list
        int randomIndex = Random.Range(0, images.Count);
        imageComponent.sprite = images[randomIndex];

        // Set initial alpha to 0
        Color color = imageComponent.color;
        color.a = 0f;
        imageComponent.color = color;

        // Gradually increase the alpha over the specified duration
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            imageComponent.color = color;
            yield return null;
        }

        // Ensure alpha is set to 1 at the end
        color.a = 1f;
        imageComponent.color = color;
    }
}
