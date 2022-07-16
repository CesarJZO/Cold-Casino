using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "Entity/Status")]
public class EntityStatus : ScriptableObject
{
    public int health;

    public GameObject currentWeapon;
}