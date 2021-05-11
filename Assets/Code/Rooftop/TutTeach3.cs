using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutTeach3 : MonoBehaviour
{
    public bool freeze;

    public float _timer = 0;
    public float _ScreenTime = 0.175f;

    public bool _screenGoUp;

    public Image myPanel;
    //float fadeTime = 3f;
    //Color colorToFadeTo;

    public Canvas mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.enabled = false;
        //myPanel.enabled = false;
        myPanel.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze == true)
        {
            Time.timeScale = 0.1f;
            _screenGoUp = true;
        }

        if(_screenGoUp == true)
        {
            //myPanel.enabled = true;
            //myPanel.GetComponent<CanvasRenderer>().SetAlpha(0.5f);
            myPanel.GetComponent<Image>().CrossFadeAlpha(1.98f, 2.0f, false);
            mainMenu.enabled = true;
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            freeze = true;
        }
    }
}
