using UnityEngine;

public class ChangeAlpha : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float speed;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float alphaTime = Time.time * speed;
        sprite.color = new Color(255, 255, 255, alphaTime);
    }
}
