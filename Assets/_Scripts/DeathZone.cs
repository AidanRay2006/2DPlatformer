using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = respawn.transform.position;
        GameManager.SubtractLife();
    }
}
