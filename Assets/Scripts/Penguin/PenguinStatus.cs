using Penguin;
using UnityEngine;

[CreateAssetMenu(fileName = "Penguin Status", menuName = "Penguin/Status")]
public class PenguinStatus : EntityStatus
{
    public PenguinController penguin;
    public int diceCounter;
}