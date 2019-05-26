using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToAR : MonoBehaviour
{
    private float time = 0.00f;

    void Start()
    {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > 2.00f)
        {
            SceneManager.LoadScene("ARScene");
        }
    }
}
