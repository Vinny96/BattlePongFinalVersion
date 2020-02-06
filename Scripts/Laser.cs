using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Block Handle 
    Block blockHandle;

    // sceneloader 
    SceneLoader sceneLoaderHandle;

    // Start is called before the first frame update
    void Start()
    {
        blockHandle = FindObjectOfType<Block>();
        sceneLoaderHandle = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            //Debug.Log("A collision with the player laser has occured.");
        }
        if(collision.gameObject.CompareTag("ComputerPaddle"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            sceneLoaderHandle.loadGameOverScene();
        }
        
        
        
        
            
        
    }

  
}
