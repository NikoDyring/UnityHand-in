using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DramaticEnding : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public Animator anim;

    public void StolenFish()
    {
        infoText.fontSize = 56;
        infoText.text = "Wh... wh.. WHERE'S MY FISHES!";
        StartCoroutine(WaitForDramaticEnding());
    }

    IEnumerator WaitForDramaticEnding()
    {
        yield return new WaitForSeconds(4);
        anim.SetTrigger("FadeOut");
    }
}
