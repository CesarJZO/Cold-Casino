using Penguin;
using UnityEngine;
using Weapons;

public class WeaponController : MonoBehaviour
{
    public Transform weaponPoint;
    public GameObject weapon;
    public WeaponInventory inventory;

    public PenguinController penguin;

    private void Update()
    {
        float angle;
        var input = penguin.settings.rawInput;

        if (input.magnitude <= penguin.settings.DeadZone)
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


    public void InstantiateWeapon()
    {
        if (weapon != null)
            Destroy(weapon);
        else
            weapon = Instantiate(inventory.RandomWeapon, weaponPoint);
    }

    public void ShootWeapon()
    {
        if (weapon is null) return;
        var offset = weaponPoint.position + weaponPoint.forward * 0.4f;
        Instantiate(inventory.Projectile, offset, weaponPoint.rotation);
    }
}
