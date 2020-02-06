using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ball locking variables
    Player playerPaddle;
    float differenceYpos;

    // ball launching variables
    [SerializeField] float velocityFactorX;
    [SerializeField] float velocityFactorY;
    [SerializeField] bool hasBallLaunched = false;
    Vector2 ballVelocity;
    Vector2 ballVelocityToAdd;

    // ball velocity variables  
    float velocityToAddX;
    float velocityToAddY;
    float velocityToSubtractX;
    float velocityToSubtractY;

    // ball audio variables
    AudioClip ballAudioClip;
    AudioSource ballAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        playerPaddle = FindObjectOfType<Player>();
        ballVelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        ballVelocityToAdd = new Vector2(velocityFactorX, velocityFactorY);

        // ball velocity variables intialization
        velocityToAddX = 3;
        velocityToAddY = 4;
        velocityToSubtractX = -3;
        velocityToSubtractY = -4;

        // ball audio variable instantiation
        ballAudioClip = this.GetComponent<AudioSource>().clip;
        ballAudioSource = this.GetComponent<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBallLaunched == false)
        {
            lockBallToPaddle();
        }
        launchBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballAudioSource.PlayOneShot(ballAudioClip,1.0f);
    }

    // methods
    private void lockBallToPaddle()
    {
        differenceYpos = this.transform.position.y - playerPaddle.transform.position.y;
        float ballXpos = playerPaddle.transform.position.x;
        float ballYpos = playerPaddle.transform.position.y + differenceYpos;
        this.transform.position = new Vector2(ballXpos,ballYpos);
    }

    public void launchBall()
    {
        if(Input.GetMouseButtonDown(0) && hasBallLaunched == false)
        {
            hasBallLaunched = true;
            Vector2 updatedBallVelocity = ballVelocity + ballVelocityToAdd;
            this.gameObject.GetComponent<Rigidbody2D>().velocity += updatedBallVelocity;
        }  
    }

    // two velocity methods one for the player and one for the computer
    public void increaseBallVelocity()
    {
       if(hasBallLaunched == true)
       {
            Vector2 velocityToAddVector = new Vector2(velocityToAddX, velocityToAddY);
            this.gameObject.GetComponent<Rigidbody2D>().velocity += velocityToAddVector;
           // Debug.Log(this.gameObject.GetComponent<Rigidbody2D>().velocity);
       }  
    }

    public void decreaseBallVelocity()
    {
        Vector2 velocityToSubtractVector = new Vector2(velocityToSubtractX, velocityToSubtractY);
        this.gameObject.GetComponent<Rigidbody2D>().velocity += velocityToSubtractVector;
       // Debug.Log(this.gameObject.GetComponent<Rigidbody2D>().velocity);
    }
}
