using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Range Weapon", menuName = "Weapons/Range")]
    public class RangeWeapon : Weapon
    {
        public GameObject bullet;
        public int cadence;
    }
}
