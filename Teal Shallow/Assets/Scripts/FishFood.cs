using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class FishFood : MonoBehaviour
{
    public PlayerController player;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            player.currentFishFood = 1;
            player.hasFood = true;

            Destroy(gameObject);
        }
    }


}
