using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour, IPowerUp<PlayerController>
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private WeaponSlots weaponSlots;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController playerController))
        {
            Activate(playerController);
            Destroy(gameObject);
        }
    }

    public void Activate(PlayerController playerController)
    {
        Transform weaponSlot = WeaponSlotSelector(playerController, weaponSlots);

        Weapon weaponToUse = Instantiate(weapon, weaponSlot);


        switch (weaponType)
        {
            case WeaponType.primaryWeapon:
                if(playerController.PrimaryWeapon!= null)
                {
                    playerController.PrimaryWeapon.DestroyWeapon();
                }

                playerController.PrimaryWeapon = weaponToUse;
                break;

            case WeaponType.secundaryWeapon:
                if (playerController.SecundaryWeapon != null)
                {
                    playerController.SecundaryWeapon.DestroyWeapon();
                }

                playerController.SecundaryWeapon = weaponToUse;
                break;
        }
    }


    private Transform WeaponSlotSelector(PlayerController playerController, WeaponSlots weaponSlots)
    {
        switch (weaponSlots)
        {
            case WeaponSlots.weaponSlotRight:
                return playerController.WeaponSlotRight;

            case WeaponSlots.weaponSlotCenter:
                return playerController.WeaponSlotCenter;

            case WeaponSlots.weaponSlotLeft:
                return playerController.WeaponSlotLeft;

            default:
                return null;
        }
    }
}
