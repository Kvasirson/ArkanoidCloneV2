using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    #region Variables
    public static EventsManager current;
    #endregion

    private void Awake()
    {
        current = this;
    }

    #region Events
    //Ball
    public event Action OnBallHasFallen;
    public event Action OnBallTouchedRacket;
    //Blocks
    public event Action OnBlockDestroyed;
    public event Action OnBlockCount;
    //GameManager
    public event Action OnPlayerWon;
    public event Action OnPlayerLost;
    #endregion

    #region CallEvents
    //Ball
    public void BallHasFallen()
    {
        OnBallHasFallen?.Invoke();
    }
    public void BallTouchedRacket()
    {
        OnBallTouchedRacket?.Invoke();
    }
    //Blocks
    public void BlockDestroyed()
    {
        OnBlockDestroyed?.Invoke();
    }
    public void BlockCount()
    {
        OnBlockCount?.Invoke();
    }
    //GameManager
    public void PlayerWon()
    {
        OnPlayerWon?.Invoke();
    }
    public void PlayerLost()
    {
        OnPlayerLost?.Invoke();
    }
    #endregion
}
