using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public Sprite objectiveComplete;
    public GameObject levelCompleteScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = objectiveComplete;

        //Remember to add a sound effect!

        levelCompleteScreen.SetActive(true);
    }
}
