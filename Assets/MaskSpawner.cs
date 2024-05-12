using UnityEngine;

public class MaskSpawner : MonoBehaviour
{
    public GameObject maskShapes;
    public int numObjs;
    void spawnMask(GameObject maskSingleShape, int numObjs)
    {
        for (int i = 0; i < numObjs; i++)
        {
            Vector3 rndSpawnPosLong = new Vector3(Random.Range(10, -10), Random.Range(10, -10), Random.Range(9.5f, 10.5f));
            GameObject singleUnitLong = Instantiate(maskSingleShape, rndSpawnPosLong, Quaternion.identity);
            singleUnitLong.transform.localScale = Vector3.one * Random.Range(6f, 2f);
            singleUnitLong.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Destroy(singleUnitLong, 0.5f);

            Vector3 rndSpawnPosHeigh = new Vector3(Random.Range(10, -10), Random.Range(10, -10), Random.Range(9.5f, 10.5f));
            GameObject singleUnitHeigh = Instantiate(maskSingleShape, rndSpawnPosHeigh, Quaternion.identity);
            singleUnitHeigh.transform.localScale = Vector3.one * Random.Range(2f, 6f);
            singleUnitHeigh.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Destroy(singleUnitHeigh, 0.5f);
        }
    }
    void FixedUpdate()
    {
        spawnMask(maskShapes, numObjs);
    }
}
