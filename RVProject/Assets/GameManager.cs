using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (_instance == null)
                    Debug.LogError("No!!!!!");
            }
            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    ////////위까지 싱글톤/////////////////
    public static int point = 0;
    
    public int getPoint()
    {
        return point;
    }

    public void plusPoint(int num)
    {
        point += num;
    }

}