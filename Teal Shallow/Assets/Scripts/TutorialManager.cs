﻿using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class TutorialManager : MonoBehaviour
    {
        [Header("Player")]
        public PlayerController player;
        [Header("Tutorial Objects")]
        public TextMeshProUGUI tutorialText;

        private bool hasReloaded = false;

        void Update()
        {
            if (player.weaponController.currentWeapon.id != 0)
            {
                tutorialText.text = "";
            }
            else
            {
                tutorialText.text = "Change weapon by pressing (1), (2) or (3)";
            }

            if (player.weaponController.currentWeapon.id == 0 || player.weaponController.currentWeapon.currentAmmo != 0 ||
                hasReloaded) return;

            tutorialText.text = "Press (R) to reload!";

            if (Input.GetButtonDown("Reload"))
            {
                hasReloaded = true;
                StartCoroutine(ClearText());
            }

            if (player.currentHealth < 100)
            {
                tutorialText.text = "Grab a med-pack to get your health back up!";
            }
        }

        private IEnumerator ClearText()
        {
            tutorialText.text = "";
            yield return new WaitForSeconds(1);
        }
    }
}
