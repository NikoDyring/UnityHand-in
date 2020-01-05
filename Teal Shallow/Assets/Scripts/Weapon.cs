using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{

    public int id;
    [Header("Weapon Settings")]
    public float fireRate;
    public float reloadTime;
    public int currentAmmo;
    public int maxAmmo;
    public Sprite weaponImage;
    [Header("Weapon Sounds")]
    public AudioClip cockingSound;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public int damage;
    
}
