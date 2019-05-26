using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenExitWindow : MonoBehaviour, IPointerDownHandler
{
    public GameObject ExitWindow;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            ExitWindow.gameObject.SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ExitWindow.gameObject.SetActive(true);
    }
}
