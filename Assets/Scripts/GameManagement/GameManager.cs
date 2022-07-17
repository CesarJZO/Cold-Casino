using Penguin;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public PenguinSettings penguinSettings;
    public PenguinStatus penguinStatus;

    public void SetRandomWeapon()
    {
        
        penguinStatus.currentWeapon = penguinStatus.penguin.inventory.RandomWeapon;
    }
}