using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage;
    public GameObject bloodPrefab;
    public WeaponController weapon;

    private void Start()
    {
        weapon = GameObject.FindWithTag("Player").GetComponent<WeaponController>();
        damage = weapon.currentWeapon.damage;
        StartCoroutine(CleanUp());
    }

    private void OnCollisionEnter2D(Collision2D col2d)
    {
        if(col2d.gameObject.tag == "Enemy")
        {
            var contact = col2d.contacts[0];
            var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Instantiate(bloodPrefab, contact.point, rot);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    private IEnumerator CleanUp()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }




}
