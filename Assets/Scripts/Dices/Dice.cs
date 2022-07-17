using UnityEngine;
[Icon("Assets/Art/User Interface/dice_icon.png")]
public class Dice : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
    }

    public void RollTheDice()
    {
        gameManager.SetRandomWeapon();
        gameManager.penguinStatus.diceCounter += 1;
    }
}
