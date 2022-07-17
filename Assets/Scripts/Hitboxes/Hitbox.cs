using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Hitbox : MonoBehaviour
{
    [SerializeField] private EntitySettings settings;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hurtbox"))
            col.SendMessage("AddDamage", settings.Damage);
        if (col.CompareTag("Collectable"))
            col.SendMessage("RollTheDice");
    }
}
