using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused;
    //Instance of Game Manager
    public static GameManager instance;

    void Awake()
    {
        //set the instance of this script
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        // Freeze Game
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle Pause Menu
        GameUI.instance.TogglePauseMenu(gamePaused);

        //toggle mouse cursor
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        curScore += score;

        //update score text
        GameUI.instance.UpdateScoreText(curScore);

        //have we reached score to win?
        if(curScore >= scoreToWin)
        {
            WinGame();
        }
    }
    public void WinGame()
    {
        //set end game sreen
        GameUI.instance.SetEndGameScreen(true,curScore);
    }

    public void LoseGame()
    {
        //set the end game screen
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;

    }
}
