using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables
    [SerializeField] int BlockHealth;

    [SerializeField] bool Indestructible;
    #endregion

    private void Start()
    {
        if (Indestructible == false)
        {
            EventsManager.current.BlockCount();
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
                EventsManager.current.BlockDestroyed();
                Destroy(gameObject);
            }
        }
    }
}
