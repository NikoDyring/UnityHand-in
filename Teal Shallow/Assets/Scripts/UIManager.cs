using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [Header("Weapon UI")]
        public WeaponController weapon;
        public TextMeshProUGUI weaponNameText;
        public TextMeshProUGUI weaponCurrentAmmoText;
        public TextMeshProUGUI weaponMaxAmmoText;
        public Image weaponImage;

        [Header("Health UI")]
        public PlayerController player;
        public TextMeshProUGUI healthText;

        [Header("FishFood UI")] 
        public TextMeshProUGUI currentFishFood;
        public GameObject fishFoodUI;
        void Start()
        {
            if (SceneManager.GetActiveScene().name == "Level_02")
            {
                fishFoodUI.SetActive(true);
            }
        }

        void Update()
        {
            // Weapon Hud
            weaponNameText.text = weapon.currentWeapon.name;
            weaponCurrentAmmoText.text = weapon.currentWeapon.currentAmmo.ToString();
            weaponMaxAmmoText.text = weapon.currentWeapon.maxAmmo.ToString();
            weaponImage.sprite = weapon.currentWeapon.weaponImage;

            // Health Hud
            healthText.text = player.currentHealth.ToString();

            // Fish Hud
            currentFishFood.text = player.currentFishFood.ToString();
        }


    }
}
