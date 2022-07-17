using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private EntitySettings settings;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hurtbox"))
            col.SendMessage("AddDamage", settings.Damage);
    }
}
