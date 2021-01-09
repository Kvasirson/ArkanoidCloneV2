using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public delegate void BallFell();
    public static event BallFell OnBallHasFallen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ball")
        {
            OnBallHasFallen?.Invoke();
        }
    }
}
