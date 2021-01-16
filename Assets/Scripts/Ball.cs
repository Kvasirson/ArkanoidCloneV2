using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables
    // Movement speed
    [SerializeField] float speed = 100f;

    //Event
    public delegate void BallFell();
    public static event BallFell OnBallHasFallen;
    public static event BallFell BallTouchedRacket;

    //Particles
    ParticleSystem BallParticules;

    //Audio
    [SerializeField] AudioClip launchball;
    [SerializeField] AudioClip bounce;
    [SerializeField] AudioClip rackettouch;

    AudioSource audiosource;

    bool PlayerIsReady;
    GameObject racket;

    #endregion

    #region Ball State
    void Start()
    {
        PlayerIsReady = false;
        racket = GameObject.Find("racket");
        //Get particle system
        BallParticules = gameObject.GetComponentInChildren<ParticleSystem>();
        //Get audioSource
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (PlayerIsReady == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerIsReady = true;
                GetComponent<Rigidbody2D>().IsAwake();
                GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

                //Particles
                BallParticules.Play();

                //Audio
                audiosource.clip = launchball;
                audiosource.Play();
            }

            if (racket != null)
            {
                this.gameObject.transform.position = new Vector3(racket.transform.position.x, racket.transform.position.y + 6, 0);
            }
        }

    }
    #endregion

    #region Collision
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.name == "racket")
        {
            //Multiplier reset
            BallTouchedRacket?.Invoke();

            //Audio
            audiosource.clip = rackettouch;
            audiosource.Play();

            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;           
        }

        // Hit Blocks ?
        if (col.gameObject.CompareTag("Block"))
        {
            audiosource.clip = bounce;
            audiosource.Play();
        }
    }
    #endregion

    #region Killzone
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Hit Killzone?
        if (col.gameObject.name == "Ball Killzone")
        {
            OnBallHasFallen?.Invoke();
            Destroy(this.gameObject, 0f);
        }
    }
    #endregion
}
