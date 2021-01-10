using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    //Object
    public GameObject BallPrefab;

    GameObject racket;

    //Counts
    [SerializeField] int BallCount;

    int score;

    int BlockCount = 0;

    //Pause
    bool GamePaused;
    #endregion

    void Awake()
    {
        Ball.OnBallHasFallen += BallHasFallen;
        Block.UpTHeScore += AddToScore;
        Block.BlockCount += CountBlocks;
    }

    private void Start()
    {
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

        else
        {
            PlayerHasLost();
        }
    }

    private void AddToScore()
    {
        score = score + 100;
        Debug.Log(score);

        //Win condition
        BlockCount = BlockCount - 1;
        if (BlockCount == 0)
        {
            PlayerHasWon();
        }
    }

    private void CountBlocks()
    {
        BlockCount = BlockCount + 1;
    }

    //Win
    private void PlayerHasWon()
    {
        Debug.Log("win");
    }

    //Loose
    private void PlayerHasLost()
    {
        Debug.Log("lost");
    }

}
