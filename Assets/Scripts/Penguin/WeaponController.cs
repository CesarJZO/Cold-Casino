using Penguin;
using UnityEngine;
using Weapons;

public class WeaponController : MonoBehaviour
{
    public GameObject weapon;
    public WeaponInventory inventory;

    public PenguinController penguin;

    private void Update()
    {
        float angle;
        var input = penguin.rawInput;

        if (input == Vector2.zero)
        {
            angle = penguin.IsFacingRight ? 0 : 180;
        }
        else
        {
            if (input.y > 0)
                angle = Vector2.Angle(input, Vector2.right);
            else
                angle = Vector2.Angle(input, Vector2.left) + 180;
        }

        transform.position = penguin.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.DrawRay(penguin.transform.position, transform.rotation * Vector3.right, Color.magenta);
    }
}
