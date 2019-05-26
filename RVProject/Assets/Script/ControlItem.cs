using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Item
{
    public string m_photo;
    public string m_name;
    public string m_pay;
    public int m_isBuy;
    public Item()
    {
        m_photo = "";
        m_name = "";
        m_pay = "";
        m_isBuy = 0;
    }
    public void setItem(string photo, string name, string pay, int isBuy)
    {
        m_photo = photo;
        m_name = name;
        m_pay = pay;
        m_isBuy = isBuy;
    }
};

public class ControlItem : MonoBehaviour
{
    public GameObject ItemObject;
    public Transform Content;
    
    void Start()
    {
        MakeItem();
    }
    
    void MakeItem()
    {
        GameObject GOTemp;
        ItemObject itemObjectTemp;
        FileStream fs = new FileStream(@"Assets\Resources\File\BallSkin.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        string srTemp = sr.ReadLine();
        while(srTemp != null)
        {
            string[] values = srTemp.Split(' ');
            GOTemp = Instantiate(this.ItemObject) as GameObject;
            itemObjectTemp = GOTemp.GetComponent<ItemObject>();
            itemObjectTemp.Photo.sprite = Resources.Load<Sprite>("Image/BallSkin/" + values[0]);
            Debug.Log(values[0]);
            itemObjectTemp.Pay.text = values[1] + "P";
            itemObjectTemp.Name.text = values[2];
            if(values[3] == "1")
            {
                itemObjectTemp.Buy.interactable = false;
            }
            else
            {
                itemObjectTemp.Equip.interactable = false;
            }
            itemObjectTemp.transform.SetParent(this.Content);
            itemObjectTemp.transform.localScale = new Vector3(1, 1, 1);

            srTemp = sr.ReadLine();
        }
    }
}