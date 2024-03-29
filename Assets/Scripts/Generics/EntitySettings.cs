﻿using UnityEngine;

public class EntitySettings : ScriptableObject
{
    [Header("Attributes")] 
    
    [SerializeField] private float speed;
    public float Speed => speed;

    [SerializeField] private float jumpStrength;
    public float JumpStrength => jumpStrength;

    [SerializeField] private int maxLife;
    public int MaxLife => maxLife;


    [Header("Damage")]
    
    [SerializeField] private int damage;
    public int Damage => damage;
    
    [Header("Physics")]
    
    [SerializeField] private LayerMask groundMask;
    public LayerMask GroundMask => groundMask;

    [SerializeField] private Vector2 groundSensorSize;
    public Vector2 GroundSensorSize => groundSensorSize;
    
    [SerializeField] private float groundDistance;
    public float GroundDistance => groundDistance;

    public PhysicsMaterial2D NoFriction => new PhysicsMaterial2D() { friction = 0, bounciness = 0, name = "No Friction" };
}