using UnityEngine;

[CreateAssetMenu(fileName = "Penguin Settings", menuName = "Penguin/Settings")]
public class PenguinSettings : EntitySettings
{
    [Header("Properties")]

    [SerializeField] private float slideForce;
    public float SlideForce => slideForce;

    [SerializeField] private float slideEscapeForce;
    public float SlideEscape => slideEscapeForce;
    
    
    [Header("Input")]

    [SerializeField] private float smoothTime;
    public float SmoothTime => smoothTime;

    [SerializeField] private float deadZone;
    public float DeadZone => deadZone;

    public Vector2 rawInput;
    
    public Vector2 smoothInput;

    
    [Header("Ceiling")]
    
    [SerializeField] private float ceilDistance;
    public float CeilDistance => ceilDistance;

    [SerializeField] private Vector2 ceilSensorSize;
    public Vector2 CeilSensorSize => ceilSensorSize;

    [SerializeField] private LayerMask ceilMask;
    public LayerMask CeilMask => ceilMask;
}