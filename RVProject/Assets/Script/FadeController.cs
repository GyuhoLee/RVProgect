using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    float fades = 1.0f;
    float time = 0;

    void Start()
    {
           
    }

    void Update()
    {
        time += Time.deltaTime;
        if(fades > 0.0f && time < 1.0f)
        {
            fades -= 0.1f;
            fade.color = new Color(0, 0, 0, fades);
        }
        else if(fades < 1.0f && time > 1.4f)
        {
            fades += 0.1f;
            fade.color = new Color(0, 0, 0, fades);
        }
    }
}
