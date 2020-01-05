using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Game Settings")]
        public int maxHealth;
        public int currentHealth;
        public int currentFishFood;

        [Header("Player Settings")]
        public Rigidbody2D playerRB;
        public WeaponController weaponController;
        public float moveSpeed = 5f;
        

        [Header("Sounds")] 
        public AudioClip footstepSound;
        public AudioClip deathSound;
        public AudioSource audioSource;

        
        [Header("Sprites")]
        public SpriteRenderer playerModel;

        [Tooltip("The different player sprites the player can access.")]
        public Sprite[] playerSprites;
        private Sprite currentSprite;
        private Vector2 movement;
        private Vector3 mousePos;
        private TutorialManager tutorialManager;

        // States
        public bool isReloading = false;
        public bool inSafeZone = true;
        public bool hasEnteredCar = false;
        public bool canEnterCar = false;
        public bool hasFood = false;
        public bool canEndMission = false;
        


        private void Start()
        {
            currentHealth = maxHealth;
            weaponController = GetComponent<WeaponController>();
            tutorialManager = GameObject.FindObjectOfType<TutorialManager>();

            if (SceneManager.GetActiveScene().name == "Level_01")
            {
                hasFood = true;
            }

        }

        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Input.GetButton("Horizontal") && !audioSource.isPlaying)
            {
                PlayFootstepSounds();
            }

            if (Input.GetButton("Vertical") && !audioSource.isPlaying)
            {
                PlayFootstepSounds();
            }

            if (Input.GetButtonDown("SwapToPistol"))
            {
                playerModel.sprite = playerSprites[0];
            }

            if (Input.GetButtonDown("SwapToShotgun"))
            {
                playerModel.sprite = playerSprites[1];
            }

            if (Input.GetButtonDown("SwapToSMG"))
            {
                playerModel.sprite = playerSprites[2];
            }

            if (Input.GetButtonDown("Reload") && weaponController.currentWeapon.currentAmmo != weaponController.currentWeapon.maxAmmo && !isReloading)
            {
                isReloading = true;
                StartCoroutine(WaitForReload());
            }

            if (Input.GetButtonDown("Interact") && canEnterCar)
            {
                if (SceneManager.GetActiveScene().name == "Level_01")
                {
                    hasEnteredCar = true;
                }

                if (SceneManager.GetActiveScene().name == "Level_02")
                {
                    canEndMission = true;
                }
            }

            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("Level_02");
            }

            FaceMouse();
        }

        private void FixedUpdate()
        {
            playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        /// <summary>
        /// Makes the player face the mouse.
        /// </summary>
        private void FaceMouse()
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector2 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        private IEnumerator WaitForReload()
        {
            currentSprite = playerModel.sprite;
            playerModel.sprite = playerSprites[3];
            yield return new WaitForSeconds(weaponController.currentWeapon.reloadTime);
            playerModel.sprite = currentSprite;
            isReloading = false;
        }

        private void PlayFootstepSounds()
        {
            audioSource.volume = Random.Range(0.8f, 1f);
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
        }

        // Checks if we collide with anything; In this case checks for the car.
        private void OnTriggerStay2D(Collider2D col2d)
        {
            if (col2d.gameObject.tag == "Car" && hasFood)
            {
                tutorialManager.EnterCar(hasFood);
                canEnterCar = true;
            }
        }

        void OnCollisionEnter2D(Collision2D col2d)
        {
            if (col2d.gameObject.tag == "Enemy")
            {
                currentHealth -= 10;
            }
        }

        private void OnTriggerExit2D(Collider2D col2d)
        {
            canEnterCar = false;
        }

    }
}
