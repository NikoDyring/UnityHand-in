using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Type 
    {
        get; 
        set;
    }

    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip[] gunCocks;
    [SerializeField]
    private AudioClip[] gunSounds;

    public Transform muzzleEnd;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    public void FireWeapon()
    {
        // TODO: Implement Weapon
        switch(Type)
            {
                case 1:
                    audio.clip = gunSounds[0];
                    audio.Play();
                    GameObject bullet = Instantiate(bulletPrefab, muzzleEnd.position, muzzleEnd.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(muzzleEnd.up * bulletForce, ForceMode2D.Impulse);
                    break;
                case 2:
                    audio.clip = gunSounds[1];
                    audio.Play();
                    Debug.Log("Shotgun PEW!");
                    break;
                case 3:
                    audio.clip = gunSounds[2];
                    audio.Play();
                    audio.volume = .7f;
                    Debug.Log("SMG PEW!");
                    break;
            }
    }

    public void SwapWeapon(int gunId)
    {
        if(gunId != Type)
        {
        switch(gunId)
            {
                case 1:
                    Debug.Log("Pistol Equipped.");
                    Type = 1;
                    audio.clip = gunCocks[0];
                    audio.Play();
                    break;
                case 2:
                    Debug.Log("Shotgun Equipped.");
                    Type = 2;
                    audio.clip = gunCocks[1];
                    audio.Play();
                    break;
                case 3:
                    Debug.Log("SMG Equipped.");
                    Type = 3;
                    audio.clip = gunCocks[2];
                    audio.Play();
                    break;
            }
        }
        
    }
}
