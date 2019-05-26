using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Click2sMoveScene : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float time = 0.00f;
    public bool isBtnDown = false;
    public string wantScene;

    private void Update()
    {
        if(isBtnDown)
        {
            time += Time.deltaTime;
        }
        if( time > 2.00f)
        {
            SceneManager.LoadScene(wantScene);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
        time = 0.0f;
    }
}
