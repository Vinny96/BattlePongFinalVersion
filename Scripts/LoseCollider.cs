using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    //scenemanager variables
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
        if(collision.gameObject.CompareTag("EnemyLaserBreakable"))
        {
            Destroy(collision.gameObject);
            Debug.Log("An enemy laser has been destroyed.");
        }
        if(collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            sceneLoaderHandle.loadGameOverScene();
            // insert code to take you to the gameOver scene. 
        }
    }
}
