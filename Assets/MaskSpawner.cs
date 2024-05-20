using System.Collections.Generic;
using UnityEngine;

public class MaskSpawner : MonoBehaviour
{
    public GameObject maskShapes;
    public List<Transform> maskShapeList = new List<Transform>();
    public int numObjs;

    void instObj(GameObject maskSingleShape, float width, float height)
    {
        Vector3 rndSpawnPos = new Vector3(Random.Range(10, -10), Random.Range(10, -10), Random.Range(9.5f, 10.5f));
        GameObject singleUnitLong = Instantiate(maskSingleShape, rndSpawnPos, Quaternion.identity);
        singleUnitLong.transform.localScale = Vector3.one * Random.Range(width, height);
        singleUnitLong.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public Vector3 RandomSpawnPos(int rangeA, int rangeB, float distanceA, float distanceB)
    {
        return new Vector3(Random.Range(rangeA, rangeB), Random.Range(rangeA, rangeB), Random.Range(distanceA, distanceB));
    }

    void spawnMask(GameObject maskShapes, int numObjs)
    {
        for (int i = 0; i <= numObjs; i++)
        {
            instObj(maskShapes, 2.5f, 5f); // long objects
            instObj(maskShapes, 5f, 2.5f); // tall objects
        }
    }
    void FixedUpdate()
    {
        spawnMask(maskShapes, numObjs);
    }
}
