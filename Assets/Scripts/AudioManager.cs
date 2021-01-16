using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables
    [SerializeField] AudioClip die;

    AudioSource audiosource;
    #endregion

    void Start()
    {
        EventsManager.current.OnBallHasFallen += playDie;
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    void playDie()
    {
        audiosource.clip = die;
        audiosource.Play();
    }
}
