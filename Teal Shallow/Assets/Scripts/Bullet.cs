using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
    }

}
