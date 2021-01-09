using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public GameObject BallPrefab;

    GameObject racket;

    [SerializeField] int BallCount;

    int score;

    bool gameIsPaused = false;
    #endregion

    void Start()
    {
        Ball.OnBallHasFallen += BallHasFallen;
        Block.UpTHeScore += AddToScore;
        racket = GameObject.Find("racket");
    }

    private void BallHasFallen()
    {
        BallCount = BallCount - 1;
        Debug.Log(BallCount);
        
        if (BallCount > 0)
        {
            GameObject.Instantiate(BallPrefab, new Vector3(racket.transform.position.x, -85, 0), new Quaternion(0, 0, 0, 0));
        }
    }

    private void AddToScore()
    {
        score = score + 100;
        Debug.Log(score);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Debug.Log("unpaused");
                Time.timeScale = 1;
                gameIsPaused = false;
            }

            else
            {
                Debug.Log("paused");
                Time.timeScale = 0;
                gameIsPaused = true;
            }
        }
    }
}
