using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public WeaponController player;

    public TextMeshProUGUI weaponNameText;
    public TextMeshProUGUI weaponCurrentAmmoText;
    public TextMeshProUGUI weaponMaxAmmoText;
    public Image weaponImage;

    void Update()
    {
        weaponNameText.text = player.currentWeapon.name;
        weaponCurrentAmmoText.text = player.currentWeapon.currentAmmo.ToString();
        weaponMaxAmmoText.text = player.currentWeapon.maxAmmo.ToString();
        weaponImage.sprite = player.currentWeapon.weaponImage;
    }

}
