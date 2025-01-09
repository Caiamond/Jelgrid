using UnityEngine;

public class Health : MonoBehaviour
{
    private float MaxHealth = 10f;
    private float HealthPoint = 10f;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoint <= 0 && spriteRenderer)
        {
            spriteRenderer.flipY = true;
        }
    }

    public void TakeDamage(float damage)
    {
        HealthPoint -= damage;
    }
}
