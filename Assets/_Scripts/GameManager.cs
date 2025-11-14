using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public static int lives = 2;
    public static int score = 0;

    public static bool _paused;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        _paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                _paused = true;
            }
            else
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                _paused = false;
            }
        }
    }

    public static void SubtractLife()
    {
        lives--;

        if(lives == 0)
        {
            //game over stuff
        }
    }
}
