using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region
    public delegate void ScoreUp();
    public static event ScoreUp UpTHeScore;

    [SerializeField] int BlockHealth;

    [SerializeField] bool Indestructible;
    #endregion


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
       if (Indestructible == false)
        {
            if (BlockHealth > 1)
            {
                BlockHealth = BlockHealth - 1;
            }

            else
            {
                UpTHeScore?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
