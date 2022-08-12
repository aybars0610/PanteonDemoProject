using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  
    private int _currentLevel;
  
    // Start is called before the first frame update
    void Start()
    {
      
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RestartButton()
    {
        // print("Restart Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
       
    }

    public void LoadScene()
    {

        int nextSceneIndex = _currentLevel + 1;
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        if (nextSceneIndex <= sceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (nextSceneIndex > sceneIndex)
        {
            SceneManager.LoadScene(0);
        }

    }
}

