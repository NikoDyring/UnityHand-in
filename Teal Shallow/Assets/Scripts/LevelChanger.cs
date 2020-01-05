using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;
    public PlayerController player;
    // Car door opening / closing for loading.
    [Header("Audio Clips")]
    public AudioClip carDoorSound;

    private int levelToLoad;
    private AudioSource playerAudio;
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        playerAudio.clip = carDoorSound;
        playerAudio.Play();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        playerAudio = player.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player.hasEnteredCar)
        {
            FadeToLevel(2);
            player.hasFood = false;
            player.hasEnteredCar = false;
        }

        if (player.canEndMission)
        {
            FadeToLevel(3);
            player.canEndMission = false;
        }
    }
}
