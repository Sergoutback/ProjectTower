using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeTo0_MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeTo1_Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeTo9_SettingsScene()
    {
        SceneManager.LoadScene(9);
    }
   
    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeTo_Scene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
