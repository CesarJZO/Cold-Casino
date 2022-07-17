using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "Entity/Status")]
public class EntityStatus : ScriptableObject
{
    [SerializeField] private int maxHealth;
    public int MaxHealth => maxHealth;

    private int _health;
    
    public int Health
    {
        set
        {
            if (value > maxHealth)
                _health = maxHealth;
            else if (value < 0)
                _health = 0;
            else
                _health = value;
        }
        get => _health;
    }

    public GameObject currentWeapon;
}