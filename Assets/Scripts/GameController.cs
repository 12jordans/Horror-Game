using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameOverScreen gameOverScreen;
    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public MouseLook mouseLook;
    public PlayerMovement playerMovement;

    public void GameOver() {
        healthBar.HideHealthBar();
        staminaBar.HideStaminaBar();
        gameOverScreen.ShowGameOverScreen();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mouseLook.StopGame();
        playerMovement.StopGame();
    }

    public void StartGame() {
        SceneManager.LoadScene("HorrorGame");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.HideGameOverScreen();
        healthBar.ShowHealthBar();
        staminaBar.ShowStaminaBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.slider.value == 0) {
            GameOver();
        }
    }
}
