using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    #region Variables
    //Pause
    bool GameIsPaused = false;
    bool CanPauseGame = true;


    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject pauseMenuUI;

    //Won
    [SerializeField] GameObject wonUI;

    //Lost
    [SerializeField] GameObject lostUI;
    #endregion

    private void Start()
    {
        EventsManager.current.OnPlayerWon += Won;
        EventsManager.current.OnPlayerLost += Lost;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CanPauseGame)
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
    }

    #region Trigger UI Menus
    #region Pause
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        gameUI.SetActive(true);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        gameUI.SetActive(false);
    }
    #endregion

    void Won()
    {
        CanPauseGame = false;
        Time.timeScale = 0f;
        wonUI.SetActive(true);
        gameUI.SetActive(false);
    }

    void Lost()
    {
        CanPauseGame = false;
        Time.timeScale = 0f;
        lostUI.SetActive(true);
         gameUI.SetActive(false);
    }
    #endregion

    #region Load Scenes
    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
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
