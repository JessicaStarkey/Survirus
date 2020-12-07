using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    public GameObject reticle;

    CursorLockMode desiredMode;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        reticle.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.visible = false;
        desiredMode = CursorLockMode.Confined;
        Camera.main.GetComponent<MouseLook>().paused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        reticle.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.visible = true;
        desiredMode = CursorLockMode.None;
        {
            Cursor.lockState = desiredMode;
        }
        Camera.main.GetComponent<MouseLook>().paused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
