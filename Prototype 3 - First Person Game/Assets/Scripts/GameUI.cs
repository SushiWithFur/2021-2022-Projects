using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("Hud")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screne")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    

    // Instance
    public static GameUI instance;

    [Header("healthBar")]
    public GameObject healthBarFull;
    public GameObject heatlhBarFourFifths;
    public GameObject healthBarThreeFifths;
    public GameObject healthBarTwoFifths;
    public GameObject healthBarOneFifth;

    void Awake()
    {
        //Set the instance to this script
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthBar(int curHP, int maxHP)
    {
        healthBarFill.fillAmount = (float)curHP / (float)maxHP;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateAmmoText( int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    public void TogglePauseMenu( bool paused )
    {
        pauseMenu.SetActive(paused);
    }

    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("0");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }    
    public void ChangeHealth(int health)
    {
        switch (health)
        {
            case 5:
                healthBarFull.SetActive(true);
                heatlhBarFourFifths.SetActive(false);
                healthBarThreeFifths.SetActive(false);
                healthBarTwoFifths.SetActive(false);
                healthBarOneFifth.SetActive(false);
                break;
            case 4:
                healthBarFull.SetActive(false);
                heatlhBarFourFifths.SetActive(true);
                healthBarThreeFifths.SetActive(false);
                healthBarTwoFifths.SetActive(false);
                healthBarOneFifth.SetActive(false);
                break;
            case 3:
                healthBarFull.SetActive(false);
                heatlhBarFourFifths.SetActive(false);
                healthBarThreeFifths.SetActive(true);
                healthBarTwoFifths.SetActive(false);
                healthBarOneFifth.SetActive(false);
                break;
            case 2:
                healthBarFull.SetActive(false);
                heatlhBarFourFifths.SetActive(false);
                healthBarThreeFifths.SetActive(false);
                healthBarTwoFifths.SetActive(true);
                healthBarOneFifth.SetActive(false);
                break;
            case 1:
                healthBarFull.SetActive(false);
                heatlhBarFourFifths.SetActive(false);
                healthBarThreeFifths.SetActive(false);
                healthBarTwoFifths.SetActive(false);
                healthBarOneFifth.SetActive(true);
                break;
            default:
                healthBarFull.SetActive(true);
                heatlhBarFourFifths.SetActive(false);
                healthBarThreeFifths.SetActive(false);
                healthBarTwoFifths.SetActive(false);
                healthBarOneFifth.SetActive(false);
                break;
        }
    }
}
