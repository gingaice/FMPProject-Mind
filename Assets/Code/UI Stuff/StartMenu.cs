using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Canvas Menu;

    // Start is called before the first frame update

    public void loadGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void loadSettingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }
    public void loadResume()
    {
        Menu.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("the game has quit");
    }
}
