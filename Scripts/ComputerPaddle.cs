using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    // computer paddle movement variables
    [SerializeField] float computerMoveSpeed;
    [SerializeField] float computerXmax;
    [SerializeField] float computerXmin;

    // computer laser Instantiation Variables
    [SerializeField] GameObject computerLaserToInstantiate = null;
    [SerializeField] int ammoCount;
    [SerializeField] int fireTracker; // will allow comptuer paddle to get 1 laser ammo every 4 bounces
    [SerializeField] float computerLaserVelocityY;
    ComputerLaserInstantiater computerLIReference; // computer laserInstantiaterReference
    PlayerLaserInstantiater playerLIReference; // player  laserInstantiaterReference


    // other variables
    Ball ballhandle;

    

    // Start is called before the first frame update
    void Start()
    {
        computerLIReference = FindObjectOfType<ComputerLaserInstantiater>();
        playerLIReference = FindObjectOfType<PlayerLaserInstantiater>();
        ballhandle = FindObjectOfType<Ball>();
        ammoCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        getComputerToMove();
        laserFiringCondition();
    }

    // methods
    private void getComputerToMove()
    {
        float deltaComputerXpos = Input.GetAxis("Horizontal") * computerMoveSpeed * Time.deltaTime;
        float updatedComputerXpos = ballhandle.transform.position.x + deltaComputerXpos;
        float clampedXpos = Mathf.Clamp(updatedComputerXpos, computerXmin, computerXmax);
        this.transform.position = new Vector2(clampedXpos, this.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballhandle.decreaseBallVelocity();
        fireTracker++;
        if(fireTracker % 3 == 0) // used to be 4
        {
            ammoCount++;
        }
    }

    private void laserFiringCondition()
    {
        if(computerLIReference.transform.position.x == playerLIReference.transform.position.x && ammoCount > 0)
        {
            StartCoroutine(FireLaser());
            ammoCount--;
        }
    }



    //coroutines
    IEnumerator FireLaser()
    {
        GameObject computerLaserHandle = Instantiate(computerLaserToInstantiate, computerLIReference.transform.position, Quaternion.identity) as GameObject;
        computerLaserHandle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, computerLaserVelocityY);
        yield return new WaitForSeconds(4.0f);
    }






}
