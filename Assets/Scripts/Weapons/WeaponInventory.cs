using UnityEngine;
using Random = UnityEngine.Random;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Weapon Inventory", menuName = "Weapons/Inventory")]
    public class WeaponInventory : ScriptableObject
    {
        public GameObject[] weapons;
        public GameObject[] projectiles;
        
        private int _index;

        public GameObject RandomWeapon
        {
            get
            {
                _index = Random.Range(0, weapons.Length);
                return weapons[_index];
            }
        }

        public GameObject Projectile => weapons[_index];
    }
}
