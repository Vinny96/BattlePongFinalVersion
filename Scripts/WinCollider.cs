using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollider : MonoBehaviour
{
    //SceneLoader Variables
     SceneLoader sceneLoaderHandle;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoaderHandle = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Playerlaser"))
        {
            Destroy(collision.gameObject);
            Debug.Log("A player laser has been destroyed.");
        }
        if(collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            sceneLoaderHandle.loadGameOverScene();
            // insert code here to get the win. 
        }
    }
}
