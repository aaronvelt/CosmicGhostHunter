using UnityEngine;

public class GunManager : MonoBehaviour
{
    public bool playerHasPistol = true;
    public bool playerHasShotgun = true;
    public string equippedWeapon;

    void Start()
    {
        SelectWeapon("Pistol");
    }

    //check if player has gun when pressing key. Equip weapon when true
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerHasPistol)
        {
            SelectWeapon("Pistol");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerHasShotgun)
        {
            SelectWeapon("Shotgun");
        }
    }

    // set selected weapon active and disable the rest
    public void SelectWeapon(string selectedWeapon)
    {
        equippedWeapon = selectedWeapon;
        foreach (Transform weapon in transform)
        {
            if (weapon.name == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            } else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }
}
