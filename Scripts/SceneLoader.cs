using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Scenemanagement variables
    int sceneLoaderIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGameScene()
    {
        sceneLoaderIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneLoaderIndex + 1);
    }

    public void loadGameOverScene()
    {
        sceneLoaderIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneLoaderIndex + 1);
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
