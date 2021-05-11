using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Canvas Menu;

    public bool LoadScene = false;
    public Image Loading;
    public Image SLoad;
    public Image loadingNow;

    void Start()
    {
        Loading.enabled = false;
        SLoad.enabled = false;
        loadingNow.enabled = false;
    }

    public void loadGame()
    {
        StartCoroutine(LoadLevel1());
        LoadScene = true;
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
    /**
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && LoadScene == false)
        {
            LoadScene = true;
            StartCoroutine(LoadLevel1());
        }
    }
    **/
    IEnumerator LoadLevel1()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Tutorial");
        SLoad.enabled = false;
        Loading.enabled = true;
        loadingNow.enabled = true;
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
