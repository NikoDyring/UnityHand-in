using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{

    public int id;
    public float fireRate;
    public float reloadTime;
    public int currentAmmo;
    public int maxAmmo;
    public AudioClip cockingSound;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    public GameObject bulletPrefab;

    public Sprite weaponImage;
}
