using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDecal : MonoBehaviour
{
    public Sprite[] bloodSprite;
    private SpriteRenderer currentSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();

        currentSprite.sprite = bloodSprite[Random.Range(0,10)];

        Destroy(gameObject, 6f);
    }



}
