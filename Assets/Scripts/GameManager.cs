using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    //Object
    public GameObject BallPrefab;

    GameObject racket;

    //Counts
    [SerializeField] int BallCount;
    int currentBallCount;

     //score
    float score;
    float scoreMultiplier;
    int BlocksHit = 1;

    int BlockCount = 0;
    #endregion

    private void Start()
    {
        //Events
        EventsManager.current.OnBallHasFallen += BallHasFallen;
        EventsManager.current.OnBallTouchedRacket += BlocksHitReset;
        EventsManager.current.OnBlockDestroyed += AddToScore;
        EventsManager.current.OnBlockCount += CountBlocks;
        racket = GameObject.Find("racket");
        currentBallCount = BallCount;
        LifeUI.lifeValue = currentBallCount;
        ScoreScript.scoreValue = score;
    }

    private void BallHasFallen()
    {
        //loose life
        
        currentBallCount = currentBallCount - 1;
        LifeUI.lifeValue = currentBallCount;
        Debug.Log(currentBallCount);

        //resset multiplier (1 life hits)
        scoreMultiplier = 0;
        BlocksHitReset();

        //loose check and respawn
        if (currentBallCount > 0)
        {
            GameObject.Instantiate(BallPrefab, new Vector3(racket.transform.position.x, -racket.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
        }

        else
        {
            EventsManager.current.PlayerLost();
        }
    }

    private void AddToScore()
    {
        //Set score
        score = score + 100 * (scoreMultiplier + BlocksHit);
        Debug.Log("Score:" + score);
        ScoreScript.scoreValue = score;
        //Set multiplier
        BlocksHit = BlocksHit + 1;
        scoreMultiplier = scoreMultiplier + 0.1f;

        //Win condition
        BlockCount = BlockCount - 1;
        Debug.Log(BlockCount);
        if (BlockCount == 0)
        {
            currentBallCount = BallCount;
            EventsManager.current.PlayerWon();
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
}
