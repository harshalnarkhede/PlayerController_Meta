using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Script : MonoBehaviour
{
    public Text fpsTxt;

    float pollingTime = 1f;
    float time;
    int frameCount;

    public GameObject FPPCamera;
    public GameObject TDPCamera;

    public TMP_Dropdown Graphic;
    public TMP_Dropdown Camera;
    public TMP_Dropdown FrameRate;

    private void Start()
    {
        Application.targetFrameRate = 30;
    }
    void Update()
    {
        time += Time.deltaTime;
        frameCount++;
        if (time > pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsTxt.text = frameRate.ToString() + " FPS";
            time -= pollingTime;
            frameCount = 0;
        }




    }

    public void ToggleGamePause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Apply()
    {


        ToggleCamera();


        ToggleFPS();

        if (Graphic.value == 0)
        {
            QualitySettings.SetQualityLevel(0, true);
        }
        else if (Graphic.value == 1)
        {
            QualitySettings.SetQualityLevel(2, true);
        }
        else if (Graphic.value == 2)
        {
            QualitySettings.SetQualityLevel(4, true);
        }
    }

    public void ToggleFPS()
    {
        int fppint = 0;
        fppint = FrameRate.value;
        if (fppint == 0)
        {
            Application.targetFrameRate = 30;
        }
        else if (fppint == 1)
        {
            Application.targetFrameRate = 60;
        }
    }


    public void ToggleCamera()
    {

        if (Camera.value == 1)
        {
            FPPCamera.SetActive(true);
            TDPCamera.SetActive(false);


        }
        else
        {
            FPPCamera.SetActive(false);
            TDPCamera.SetActive(true);

        }

    }
}
