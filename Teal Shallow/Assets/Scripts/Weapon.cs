using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }

        if(Input.GetButtonDown("SwapToPistol"))
        {
            SwapWeapon(1);
        }

        if(Input.GetButtonDown("SwapToShotgun"))
        {
            SwapWeapon(2);
        }

        if(Input.GetButtonDown("SwapToSMG"))
        {
            SwapWeapon(3);
        }
    }

    void FireWeapon()
    {
        // TODO: Implement Weapon
        Debug.Log("Pew!");
    }

    void SwapWeapon(int gunId)
    {
        switch(gunId)
        {
            case 1:
                Debug.Log("Pistol Equipped.");
                break;
            case 2:
                Debug.Log("Shotgun Equipped.");
                break;
            case 3:
                Debug.Log("SMG Equipped.");
                break;
        }
    }
}
