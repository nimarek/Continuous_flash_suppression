using UnityEngine;

public class RndImage : MonoBehaviour
{
    public GameObject imgSpawner;
    public float distance;

    void Start()
    {
        imgSpawner.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
    }
}
