using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideExitWindow : MonoBehaviour, IPointerDownHandler
{
    public GameObject ExitWindow;

    public void OnPointerDown(PointerEventData eventData)
    {
        ExitWindow.gameObject.SetActive(false);
    }
}
