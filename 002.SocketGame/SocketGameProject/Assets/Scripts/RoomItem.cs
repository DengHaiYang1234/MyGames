using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class RoomItem:MonoBehaviour
{
    //auto
    private Text Txt_UserName = null;
	private Text Txt_TotalCount = null;
	private Text Txt_WinCount = null;
	private Button Btn_Join = null;
	
    public void Start()
    {
        Txt_UserName = gameObject.transform.Find("Txt_UserName").GetComponent<Text>();
		Txt_TotalCount = gameObject.transform.Find("Txt_TotalCount").GetComponent<Text>();
		Txt_WinCount = gameObject.transform.Find("Txt_WinCount").GetComponent<Text>();
		Btn_Join = gameObject.transform.Find("Btn_Join").GetComponent<Button>();
		AddClicks();
    }

    private void AddClicks()
    {
        Btn_Join.onClick.AddListener(OnJoinClick);
	
    }


    private void OnJoinClick(){
	}

    public void SerRoomInfo(string userName, int totalCount, int winCount)
    {
        Txt_UserName.text = userName;
        Txt_TotalCount.text = "总场次：" + totalCount.ToString();
        Txt_WinCount.text = "胜利：" + winCount.ToString();
    }

    public void SerRoomInfo(string userName, string totalCount, string winCount)
    {
        Txt_UserName.text = userName;
        Txt_TotalCount.text = "总场次：" + totalCount;
        Txt_WinCount.text = "胜利：" + winCount;
    }


    //autoEnd
}
            