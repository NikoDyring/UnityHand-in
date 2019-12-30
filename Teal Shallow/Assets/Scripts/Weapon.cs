using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Type
    {
        get;
        set;
    }
    #region Audio Fields 
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip[] gunCocks;
    [SerializeField]
    private AudioClip[] gunSounds;
    #endregion
    
    public Transform muzzleEnd;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireRate;
    public float nextShot;
    public float reloadTime;

    private GameObject bullet;
    private Rigidbody2D rb2d;

    public void FireWeapon()
    {
        nextShot = Time.time + 1f / fireRate;
        switch (Type)
        {
            case 1:
                audio.clip = gunSounds[0];
                audio.Play();
                bullet = Instantiate(bulletPrefab, muzzleEnd.position, muzzleEnd.rotation);
                rb2d = bullet.GetComponent<Rigidbody2D>();
                rb2d.AddForce(muzzleEnd.up * bulletForce, ForceMode2D.Impulse);
                break;
            case 2:
                // Implement spread pattern for shotgun
                audio.clip = gunSounds[1];
                audio.Play();
                Debug.Log("Shotgun PEW!");
                break;
            case 3:
                audio.clip = gunSounds[2];
                audio.Play();
                bullet = Instantiate(bulletPrefab, muzzleEnd.position, muzzleEnd.rotation);
                rb2d = bullet.GetComponent<Rigidbody2D>();
                rb2d.AddForce(muzzleEnd.up * bulletForce, ForceMode2D.Impulse);
                Debug.Log("SMG PEW!");
                break;
        }
    }

    public void SwapWeapon(int gunId)
    {
        if (gunId != Type)
        {
            switch (gunId)
            {
                case 1:
                    Debug.Log("Pistol Equipped.");
                    Type = 1;
                    audio.clip = gunCocks[0];
                    audio.Play();
                    fireRate = 3f;
                    break;
                case 2:
                    Debug.Log("Shotgun Equipped.");
                    Type = 2;
                    audio.clip = gunCocks[1];
                    audio.Play();
                    fireRate = 1f;
                    break;
                case 3:
                    Debug.Log("SMG Equipped.");
                    Type = 3;
                    audio.clip = gunCocks[2];
                    audio.Play();
                    fireRate = 10f;
                    break;
            }
        }

    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextShot)
        {
            nextShot = Time.time + 1f / fireRate;
            FireWeapon();
        }

        if (Input.GetButtonDown("SwapToPistol"))
        {
            SwapWeapon(1);
        }

        if (Input.GetButtonDown("SwapToShotgun"))
        {
            SwapWeapon(2);
        }

        if (Input.GetButtonDown("SwapToSMG"))
        {
            SwapWeapon(3);
        }

        if (Input.GetButtonDown("Reload"))
        {

        }
    }
}