using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool Triggered = false;
    public Mover TriggeredObject;
    public Sprite pressedSprite;

    private AudioSource pressedSound;

    private void Start()
    {
        pressedSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            pressedSound.Play();

            TriggeredObject.Moving = true;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = pressedSprite;
        }
    }
}
