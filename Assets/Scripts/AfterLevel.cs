using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterLevel : MonoBehaviour
{
    int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void OnNext()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
