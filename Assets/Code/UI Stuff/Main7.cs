using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main7 : MonoBehaviour
{
    public bool LoadScene = false;
    public Image Loading;
    public Image SLoad;
    public Image loadingNow;
    // Start is called before the first frame update
    void Start()
    {
        Loading.enabled = false;
        SLoad.enabled = true;
        loadingNow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && LoadScene == false)
        {
            LoadScene = true;
            StartCoroutine(LoadLevel1());
        }
    }
    IEnumerator LoadLevel1()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Year 7");
        SLoad.enabled = false;
        Loading.enabled = true;
        loadingNow.enabled = true;
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}