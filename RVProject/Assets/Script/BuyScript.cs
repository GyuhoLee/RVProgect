using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyScript : MonoBehaviour, IPointerDownHandler
{
    int point;
    public Text name;
    public Text payText;
    public Button equip;
    int pay;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable == false)
        {
            return;
        }
        if (BuyItem())
        {
            GameObject.Find("Message").GetComponent<MessagePopup>().InputMessage("구매가 완료되었습니다.");
            StartCoroutine(WaitForIt());
        #if (UNITY_EDITOR || UNITY_STANDALONE_WIN)
            GameObject.Find("FileManager").GetComponent<FileManagement>().Write0To1InWeb(name.GetComponent<Text>().text);
        #elif UNITY_ANDROID
            GameObject.Find("FileManager").GetComponent<FileManagement>().Write0To1InAndroid(name.GetComponent<Text>().text);
        #endif
        }
        else
        {
            GameObject.Find("Message").GetComponent<MessagePopup>().InputMessage("Point가 부족합니다.");
            StartCoroutine(WaitForIt());
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("Message").GetComponent<MessagePopup>().InputMessage("");
    }

    public bool BuyItem()
    {
        point = GameManager.Instance.getPoint();
        string payTemp = payText.GetComponent<Text>().text.Replace("P", "");
        pay = System.Int32.Parse(payTemp);
        if (point >= pay)
        {
            point -= pay;
            GameManager.Instance.plusPoint(-1 * pay);
            gameObject.GetComponent<Button>().interactable = false;
            equip.interactable = true;
            //N -> Y 로 바꿔주는 작업 필요
            return true;
        }
        else
        {
            return false;
        }

    }
}
