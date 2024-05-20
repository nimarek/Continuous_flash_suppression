using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaskSpawner : MonoBehaviour
{
    public GameObject quadPrefab; 
    public int numberOfQuads = 500; 
    public float interval = 0.01f; 
    public float xRange = 5; 
    public float yRange = 5; 
    public float minSize = 1.5f;
    public float maxSize = 2.5f;
    public float maskDistance = 5f;
    public Camera mainCamera;

    private List<GameObject> spawnedQuads = new List<GameObject>();

    void Start()
    {
        if (quadPrefab == null)
        {
            Debug.LogError("Quad prefab is not assigned.");
            return;
        }
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        StartCoroutine(SpawnQuads());
    }

    IEnumerator SpawnQuads()
    {
        while (true)
        {
            foreach (GameObject quad in spawnedQuads)
            {
                Destroy(quad);
            }
            spawnedQuads.Clear();

            mainCamera.backgroundColor = new Color(
                Random.value,
                Random.value,
                Random.value,
                1f);

            for (int i = 0; i < numberOfQuads; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(-xRange, xRange),
                    Random.Range(-yRange, yRange),
                    mainCamera.transform.position.z + maskDistance);

                GameObject quad = Instantiate(quadPrefab, randomPosition, Quaternion.identity);
                spawnedQuads.Add(quad);

                float randomWidth = Random.Range(minSize, maxSize);
                float randomHeight = Random.Range(minSize, maxSize);
                quad.transform.localScale = new Vector3(randomWidth, randomHeight, 1f);

                Renderer renderer = quad.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = new Color(
                        Random.value,
                        Random.value, 
                        Random.value, 
                        1f); 
                }
            }
            yield return new WaitForSeconds(interval);
        }
    }
}