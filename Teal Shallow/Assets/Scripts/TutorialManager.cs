using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class TutorialManager : MonoBehaviour
    {
        [Header("Player")]
        public PlayerController player;
        [Header("Tutorial Objects")]
        public TextMeshProUGUI tutorialText;

        private TextMeshProUGUI infoText;
        private bool hasReloaded = false;
        private bool hasBeenInCar = false;
        private bool hasCompletedObjective = false;
        private GameObject infoGameObject;
        void Awake()
        {
            infoGameObject = GameObject.Find("InfoText");
            infoText = infoGameObject.GetComponent<TextMeshProUGUI>();
            if (SceneManager.GetActiveScene().name == "Level_02")
            {
                infoText.text = "";
                tutorialText.text = "Change weapon by pressing (1), (2) or (3)";
            }

            Debug.Log(SceneManager.GetActiveScene().name);

            StartCoroutine(ClearInfoText(5));
            StartCoroutine(ClearTutorialText());
        }

        void Update()
        {
            if ((SceneManager.GetActiveScene().name == "Level_02" && player.hasFood) && !hasCompletedObjective)
            {
                
                tutorialText.text = "Phew! Time to go home to the fishes!";
                hasCompletedObjective = true;
                StartCoroutine(ClearTutorialText());
            }

            if (player.weaponController.currentWeapon.id == 0 || player.weaponController.currentWeapon.currentAmmo != 0 ||
                hasReloaded) return;

            tutorialText.text = "Press (R) to reload!";

            if (Input.GetButtonDown("Reload"))
            {
                hasReloaded = true;
                StartCoroutine(ClearTutorialText());
            }
        }

        private IEnumerator ClearTutorialText()
        {
            yield return new WaitForSeconds(6);
            tutorialText.text = "";
        }

        private IEnumerator ClearInfoText(int secondsToWait)
        {
            yield return new WaitForSeconds(secondsToWait);
            infoText.text = "";
        }

        public void EnterCar(bool enterCar)
        {
            if (enterCar)
            {
                tutorialText.text = "Press (E) to enter car.";
            }
            else
            {
                tutorialText.text = "";
            }

        }

    }
}
