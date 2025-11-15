using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreboard;
    public GameObject[] lives;
    public GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._gameOver)
        {
            gameOverScreen.SetActive(true);
            return;
        }


        scoreboard.text = GameManager.score.ToString();

        //hide all the lives
        for (int i =0; i < lives.Length; i++)
        {
            lives[i].SetActive(false);
        }
        //reveal the correct number of lives
        for (int i = 0; i < GameManager.lives; i++)
        {
            lives[i].SetActive(true);
        }
    }
}
