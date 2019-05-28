using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopup : MonoBehaviour
{
    public void InputMessage(string message)
    {
        gameObject.GetComponent<Text>().text = message;
    }

}
