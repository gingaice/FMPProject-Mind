using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutElevator : MonoBehaviour
{
    public bool LoadScene = false;
    public Image Loading;
    // Start is called before the first frame update
    void Start()
    {
        Loading.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            StartCoroutine(LoadLevel1());
            LoadScene = true;
        }
    }

    IEnumerator LoadLevel1()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");
        Loading.enabled = true;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
