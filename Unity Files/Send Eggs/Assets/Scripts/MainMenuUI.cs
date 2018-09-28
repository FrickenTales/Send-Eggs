using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public Button play, settings, quit;

    // Use this for initialization
    void Start()
    {
        play.onClick.AddListener(OnClickPlay);
        //settings.onClick.AddListener(OnClickSettings);
        quit.onClick.AddListener(OnClickQuit);
    }

    void OnClickPlay()
    {
        SceneManager.LoadScene("LevelScene");
    }

    void OnClickSettings()
    {

    }

    void OnClickQuit()
    {
        Application.Quit();
    }
}
