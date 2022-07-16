using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entity/Stats")]
public class EntitySettings : ScriptableObject
{
    [Header("Attributes")] 
    
    [SerializeField] private float speed;
    public float Speed => speed;

    [SerializeField] private float jumpStrength;
    public float JumpStrength => jumpStrength;

    [SerializeField] private int maxLife;
    public int MaxLife => maxLife;


    [Header("Physics")]
    
    [SerializeField] private LayerMask groundMask;
    public LayerMask GroundMask => groundMask;

    [SerializeField] private float groundDistance;
    public float GroundDistance => groundDistance;
}