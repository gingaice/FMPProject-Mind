using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Canvas Menu;
    // Start is called before the first frame update
    void Start()
    {
        Menu.enabled = false;
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }
    public void loadSettings()
    {
        SceneManager.LoadScene("Settings");
        Time.timeScale = 1;
    }
}
