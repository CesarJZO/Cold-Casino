using System;
using System.Collections;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [Header("Settings")] 
    public float animationTime;
    public Color damageColor;
    private readonly Color _originalColor = Color.white;
    
    [Header("Dependencies")]
    public EntityStatus status;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        status.Health = status.MaxHealth;
    }

    public void AddDamage(int amount)
    {
        status.Health -= amount;
        StartCoroutine(DamageAnimation());
    }

    public void AddHealth(int amount)
    {
        status.Health += amount;
    }

    private IEnumerator DamageAnimation()
    {
        var elapsed = 0f;
        while (elapsed <= animationTime)
        {
            var t = Mathf.Abs(Mathf.Sin(elapsed * 90 * Mathf.Deg2Rad));
            spriteRenderer.color = Color.Lerp(_originalColor, damageColor, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}