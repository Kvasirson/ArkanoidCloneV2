using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    #region Variables
    //Pause
    public static bool GameIsPaused = false;

    [SerializeField] GameObject pauseMenuUI;

    //Won
    [SerializeField] GameObject wonUI;

    //Lost
    [SerializeField] GameObject lostUI;
    #endregion

    private void Awake()
    {
        GameManager.PlayerWon += Won;
        GameManager.PlayerLost += Lost;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    #region Trigger UI Menus
    #region Pause
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    #endregion

    void Won()
    {
        wonUI.SetActive(true);
    }

    void Lost()
    {
        lostUI.SetActive(true);
    }
    #endregion

    #region Load Scenes
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    #endregion



    public void QuitGame()
    {
        Application.Quit();
    }
}
