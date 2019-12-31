using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    void Start()
    {
        StartCoroutine(CleanUp());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    IEnumerator CleanUp()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
