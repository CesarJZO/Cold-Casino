using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Hitbox : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hurtbox"))
            col.SendMessage("AddDamage", damage);
        if (col.CompareTag("Collectable"))
            col.SendMessage("RollTheDice");
    }
}
