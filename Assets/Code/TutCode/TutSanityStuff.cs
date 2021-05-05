using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutSanityStuff : MonoBehaviour
{
    public float damageInsanity = 50;
    public float Mhealth = 500;
    public bool inSight;

    //time for timers and health
    public float regenTime;
    public bool regenTrue;

    public Canvas menu;

    public static bool isSafe;

    public static float shift = 1;
    private Texture texture;
    private Material material;

    public float _increaseAmount = 1;
    public float increaser = 1;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        menu.enabled = false;
        inSight = false;
    }

    void Awake()
    {
        material = new Material(Shader.Find("Hidden/Distortion"));
        texture = Resources.Load<Texture>("Checkerboard-big");
    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_ValueX", shift);
        material.SetTexture("_Texture", texture);
        Graphics.Blit(source, destination, material);
    }

    // Update is called once per frame
    void Update()
    {
        shift = _increaseAmount;

        if (TutFOVDetection.checker == true)
        {
            Mhealth -= Time.deltaTime * damageInsanity;
            inSight = true;
            _increaseAmount += Time.deltaTime * increaser;
        }
        else
        {
            inSight = false;
        }

        if (inSight == true)
        {
            regenTime = 0;
            regenTrue = false;
        }
        else
        {
            regenTrue = true;
        }

        if (regenTrue == true)
        {
            regenTime += Time.deltaTime * damageInsanity;
        }

        if (regenTime >= 500)
        {
            Mhealth += Time.deltaTime * damageInsanity;
        }

        if (Mhealth >= 500)
        {
            Mhealth = 500;
        }

        if (Mhealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Player Died");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.enabled = true;
            inSight = false;
        }

        if (menu.enabled == true)
        {
            Mhealth = 500;
            inSight = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "VisionSafeSpace")
        {
            isSafe = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "VisionSafeSpace")
        {
            isSafe = false;
        }
    }
}