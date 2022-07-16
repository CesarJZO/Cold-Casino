using UnityEngine;

namespace Weapons
{
    public class Weapon : ScriptableObject
    {
        public GameObject prefab;

        [SerializeField] private int damageMagnitude;
        public int DamageMagnitude => damageMagnitude;
    }
}
