using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private float moveSpeed = 5f;
    public Rigidbody2D playerRB;
    public WeaponController weaponController;

    [SerializeField]
    private SpriteRenderer playerModel;

    [SerializeField]
    private Sprite[] playerSprites;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        currentHealth = maxHealth;
        weaponController = GetComponent<WeaponController>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


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

        if (Input.GetButtonDown("Reload"))
        {
            playerModel.sprite = playerSprites[3];
            WaitForReload();
            
        }


        FaceMouse();
    }

    void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(weaponController.currentWeapon.reloadTime);
    }
}
