using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables
    [SerializeField] AudioClip die;

    AudioSource audiosource;
    #endregion

    private void Awake()
    {
        EventsManager.current.OnBallHasFallen += playDie;
    }

    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    void playDie()
    {
        audiosource.clip = die;
        audiosource.Play();
    }
}
