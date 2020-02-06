using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // player moving variables
    float deltaXpos;
    float updatedXpos;
    float clampedXpos;
    Vector2 playermovement;
    [SerializeField] float xMinDistance;
    [SerializeField] float xMaxDistance;
    [SerializeField] float moveSpeed = 0;

    // laser firing variables
     PlayerLaserInstantiater playerLaserInstantiaterHandle;
    [SerializeField] int fireTracker; // will be the one that allows for firing
    [SerializeField] int maxLaserAmmo;
    [SerializeField] int ammoCount;

    // sceneloade varaibles
    SceneLoader sceneLoaderHandle;


    // other variables
    Ball ballhandle;


    // autoplay variables
    [SerializeField] bool isAutoPlayOn;
    
   
    // Start is called before the first frame update
    void Start()
    {
        fireTracker = 0;
        maxLaserAmmo = 1; // used to be three changing it to 1
        ammoCount = 0;
        playerLaserInstantiaterHandle = FindObjectOfType<PlayerLaserInstantiater>();
        ballhandle = FindObjectOfType<Ball>();
        sceneLoaderHandle = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        autoPlay();
        
        if(Input.GetButtonDown("Fire1"))
        {
            FireLaser();
        }
    }

    // list of methods
    
    private void autoPlay()
    {
        if(isAutoPlayOn == true)
        {
            Vector2 playerAutoVector = new Vector2(ballhandle.transform.position.x, this.transform.position.y);
            this.transform.position = playerAutoVector;
        }
    }

    private void movePlayer()
    {
        deltaXpos = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        updatedXpos = this.transform.position.x + deltaXpos;
        clampedXpos = Mathf.Clamp(updatedXpos, xMinDistance, xMaxDistance);
        playermovement = new Vector3(clampedXpos, this.transform.position.y,this.transform.position.z);
        this.transform.position = playermovement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballhandle.increaseBallVelocity();
        fireTracker++;
        if (fireTracker % 4 == 0)
        {
            ammoCount++;
        }
        else { }
        if(collision.gameObject.tag == "EnemyLaserBreakable")
        {
            Debug.Log("PlayerPaddle should be getting destroyed.");
            sceneLoaderHandle.loadGameOverScene();
            Destroy(gameObject);
        }
    }

    private void FireLaser()
    {
        if(ammoCount >= maxLaserAmmo)
        {
            playerLaserInstantiaterHandle.InstantiatePlayerLaser();
            ammoCount--;
        }
        else
        {
            Debug.Log("No Ammo cannot fire laser");
        }
    }  
}
