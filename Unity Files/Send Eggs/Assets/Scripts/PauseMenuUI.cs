using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{

    public Button toMenu;

    // Use this for initialization
    void Start()
    {
        toMenu.onClick.AddListener(OnClicktoMenu);
    }

    void OnClicktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
