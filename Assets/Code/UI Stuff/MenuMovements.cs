using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMovements : MonoBehaviour
{
    public Canvas Menu;
    // Start is called before the first frame update
    void Start()
    {
        Menu.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
    public void loadGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }
    public void loadSettingsMenu()
    {
        SceneManager.LoadScene("Settings");
        Time.timeScale = 1;
    }
    public void loadResume()
    {
        Menu.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("the game has quit");
    }
}
