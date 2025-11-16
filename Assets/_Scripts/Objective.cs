using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public Sprite objectiveComplete;
    public GameObject levelCompleteScreen;

    private AudioSource winSound;

    private void Start()
    {
        winSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = objectiveComplete;

        levelCompleteScreen.SetActive(true);

        winSound.Play();
    }
}
