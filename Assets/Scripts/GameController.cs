using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameOverScreen gameOverScreen;
    public PauseScreen pauseScreen;
    public GameObject inventoryPanel;
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

    public void PauseGame() {
        Time.timeScale = 0;
        healthBar.HideHealthBar();
        staminaBar.HideStaminaBar();
        pauseScreen.ShowPauseScreen();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mouseLook.StopGame();
        playerMovement.StopGame();

        if (inventoryPanel.gameObject.activeSelf) {
            inventoryPanel.gameObject.SetActive(false);
        }
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        pauseScreen.HidePauseScreen();
        healthBar.ShowHealthBar();
        staminaBar.ShowStaminaBar();
        mouseLook.StartGame();
        playerMovement.StartGame();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StartGame() {
        SceneManager.LoadScene("HorrorGame");
        Time.timeScale = 1;
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.HideGameOverScreen();
        pauseScreen.HidePauseScreen();
        healthBar.ShowHealthBar();
        staminaBar.ShowStaminaBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.slider.value == 0) {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseScreen.gameObject.activeSelf) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }
}
