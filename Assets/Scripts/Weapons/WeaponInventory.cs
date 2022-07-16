using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Weapon Inventory", menuName = "Weapons/Inventory")]
    public class WeaponInventory : ScriptableObject
    {
        public GameObject[] weapons;

        public GameObject RandomWeapon => weapons[Random.Range(0, weapons.Length)];
    }
}
