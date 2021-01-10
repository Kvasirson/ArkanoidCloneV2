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

     //score
    float score;
    float scoreMultiplier;
    int BlocksHit = 1;

    int BlockCount = 0;

    //Pause
    bool GamePaused;
    #endregion

    void Awake()
    {
        Ball.OnBallHasFallen += BallHasFallen;
        Ball.BallTouchedRacket += BlocksHitReset;
        Block.UpTHeScore += AddToScore;
        Block.BlockCount += CountBlocks;
    }

    private void Start()
    {
        racket = GameObject.Find("racket");
    }

    private void BallHasFallen()
    {
        //loose life
        BallCount = BallCount - 1;
        Debug.Log(BallCount);

        //resset multiplier (1 life hits)
        scoreMultiplier = 1;
        
        //loose check and respawn
        if (BallCount > 0)
        {
            GameObject.Instantiate(BallPrefab, new Vector3(racket.transform.position.x, -racket.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
        }

        else
        {
            PlayerHasLost();
        }
    }

    private void AddToScore()
    {
        //Set score
        score = score + 100 * (scoreMultiplier + BlocksHit);
        Debug.Log(score);

        //Set multiplier
        BlocksHit = BlocksHit + 1;
        scoreMultiplier = scoreMultiplier + 0.1f;

        //Win condition
        BlockCount = BlockCount - 1;
        if (BlockCount == 0)
        {
            PlayerHasWon();
        }
    }

    //Reset multiplier (1 throw hits)
    private void BlocksHitReset()
    {
        BlocksHit = 1;
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
