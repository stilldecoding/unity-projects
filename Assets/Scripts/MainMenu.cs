using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int LevelIndex = 1;
    public void OnLoadScene()
    {
        SceneManager.LoadScene(LevelIndex);
    }

    public void OnSetting()
    {
        return;
    }

    public void OnExit()
    {
        return;
    }
}
