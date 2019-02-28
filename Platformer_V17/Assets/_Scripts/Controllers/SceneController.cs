using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance = null;
    public int lastLevel = 3;

    void Awake()
    {
        singleton();
    }

    public void changeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void nextLevel(int currentLevel)
    {
        Debug.Log("Current Level: " + GameBehaviour.instance.getCurrentLevel() + " maxLevel: " + lastLevel);
        if (currentLevel>lastLevel)
        {
            GameBehaviour.instance.reset();
            GameBehaviour.instance.levelEnd();
        } else
        {
            changeScene(currentLevel+1);
        }
    }

    void singleton()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
}
