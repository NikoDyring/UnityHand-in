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

    void OnCollisionEnter2D(Collision2D col2d)
    {
        Debug.Log(col2d.gameObject);
        if(col2d.gameObject.tag == "Enemy")
        { 
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
