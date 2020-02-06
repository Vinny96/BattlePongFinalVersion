using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserInstantiater : MonoBehaviour
{
    // laser instantiation variables
    [SerializeField] GameObject laserToInstantiate;
    Player playerPaddleToReference;

    // laser velocity variables
    [SerializeField] float playerLaserVelocityYFactor;

    // Start is called before the first frame update
    void Start()
    {
        playerPaddleToReference = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        lockLaserInstantiaterToPaddle();
    }

    // methods
    public void InstantiatePlayerLaser()
    {
        Vector2 laserPosition = new Vector2(this.transform.position.x,this.transform.position.y);
        GameObject laserToInstantiateHandle = Instantiate(laserToInstantiate, laserPosition, Quaternion.identity);
        laserToInstantiateHandle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerLaserVelocityYFactor);
    }

    private void lockLaserInstantiaterToPaddle()
    {
        this.transform.position = new Vector2(playerPaddleToReference.transform.position.x, playerPaddleToReference.transform.position.y - getDifferenceBetweenLaserAndPaddle());
    }

    private float getDifferenceBetweenLaserAndPaddle()
    {
        float differenceInYPos = playerPaddleToReference.transform.position.y - this.transform.position.y;
        return differenceInYPos;
    }
    
    
 
    
    // the instantiation method is what is causing the player laser to lock with the paddle. 
    


}
   
