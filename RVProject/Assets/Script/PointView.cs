using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointView : MonoBehaviour
{
    Text point;
    int iPointTemp;

    void Start()
    {
        point = GetComponent<Text>();
    }

    void Update()
    {
        iPointTemp = GameManager.Instance.getPoint();
        point.text = "point : " + iPointTemp.ToString() + "p";
    }
}
