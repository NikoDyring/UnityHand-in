using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int Type { get; set; }
    public bool IsReloading { get; set; }

    [SerializeField]
    private AudioSource audio;

    public Transform muzzleEnd;

    public float bulletForce = 20f;
    public float nextShot;

    public Weapon currentWeapon;
    public Weapon[] weapons;



    private GameObject bullet;
    private Rigidbody2D rb2d;

    void Start()
    {
        weapons[0].currentAmmo = 8;
        weapons[1].currentAmmo = 6;
        weapons[2].currentAmmo = 30;
    }


    public void FireWeapon(Weapon weapon)
    {
        nextShot = Time.time + 1f / weapon.fireRate;
        switch (weapon.id)
        {
            case 1:
                audio.clip = weapon.shotSound;
                audio.Play();
                bullet = Instantiate(weapon.bulletPrefab, muzzleEnd.position, muzzleEnd.rotation);
                rb2d = bullet.GetComponent<Rigidbody2D>();
                rb2d.AddForce(muzzleEnd.up * bulletForce, ForceMode2D.Impulse);
                break;
            case 2:
                audio.clip = weapon.shotSound;
                audio.Play();
                bullet = Instantiate(weapon.bulletPrefab, muzzleEnd.position, muzzleEnd.rotation);
                rb2d = bullet.GetComponent<Rigidbody2D>();
                rb2d.AddForce(muzzleEnd.up * bulletForce, ForceMode2D.Impulse);
                break;
            case 3:
                audio.clip = weapon.shotSound;
                audio.Play();
                bullet = Instantiate(weapon.bulletPrefab, muzzleEnd.position, muzzleEnd.rotation);
                rb2d = bullet.GetComponent<Rigidbody2D>();
                rb2d.AddForce(muzzleEnd.up * bulletForce, ForceMode2D.Impulse);
                break;
        }
        weapon.currentAmmo -= 1;
    }

    public void SwapWeapon(Weapon weapon)
    {
        if (currentWeapon.id != weapon.id)
        {
            switch (weapon.id)
            {
                case 1:
                    Debug.Log("Pistol Equipped.");
                    audio.clip = weapon.cockingSound;
                    audio.Play();
                    currentWeapon = weapon;
                    break;
                case 2:
                    Debug.Log("Shotgun Equipped.");
                    audio.clip = weapon.cockingSound;
                    audio.Play();
                    currentWeapon = weapon;
                    break;
                case 3:
                    Debug.Log("SMG Equipped.");
                    audio.clip = weapon.cockingSound;
                    audio.Play();
                    currentWeapon = weapon;
                    break;
            }
        }
    }

    public void Reload(Weapon weapon)
    {
        if (IsReloading)
            return;

        switch (weapon.id)
        {
            case 1:
                audio.clip = weapon.reloadSound;
                audio.Play();
                break;
            case 2:
                audio.clip = weapon.reloadSound;
                audio.Play();
                break;
            case 3:
                audio.clip = weapon.reloadSound;
                audio.Play();
                break;
        }

        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine()
    {
        IsReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(currentWeapon.reloadTime);

        switch (currentWeapon.id)
        {
            case 1:
                currentWeapon.currentAmmo = 7;
                break;
            case 2:
                currentWeapon.currentAmmo = 6;
                break;
            case 3:
                currentWeapon.currentAmmo = 30;
                break;
        }
        IsReloading = false;
        Debug.Log("Done Reloading");
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextShot && currentWeapon.currentAmmo > 0)
        {
            if (!IsReloading)
            {
                nextShot = Time.time + 1f / currentWeapon.fireRate;
                FireWeapon(currentWeapon);
            }
        }

        if (Input.GetButtonDown("SwapToPistol"))
        {
            SwapWeapon(weapons[0]);
        }

        if (Input.GetButtonDown("SwapToShotgun"))
        {
            SwapWeapon(weapons[1]);
        }

        if (Input.GetButtonDown("SwapToSMG"))
        {
            SwapWeapon(weapons[2]);
        }

        if (Input.GetButtonDown("Reload"))
        {
            Reload(currentWeapon);
        }
    }
}