using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables
    //events
    public delegate void ScoreUp();
    public static event ScoreUp UpTHeScore;
    public static event ScoreUp BlockCount;

 
    [SerializeField] int BlockHealth;

    [SerializeField] bool Indestructible;
    #endregion

    private void Start()
    {
        if (Indestructible == false)
        {
            BlockCount?.Invoke();
        }
    }


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
