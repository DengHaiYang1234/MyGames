using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class RoomPanel : BasePanel
{
    //auto
    private Text Txt_Name = null;
    private Text Txt_Scene = null;
    private Text Txt_WinNum = null;
    private ScrollRect Scroll_View = null;
    private Scrollbar Scrollbar_Vertical = null;
    private Button Btn_CreatRoom = null;
    private Button Btn_Close = null;
    private Button Btn_Refresh = null;
    private GameObject roomItemPrefab;
    private GameObject grid;

    public void Start()
    {
        Txt_Name = gameObject.transform.Find("BattleRes/Txt_Name").GetComponent<Text>();
        Txt_Scene = gameObject.transform.Find("BattleRes/Txt_Scene").GetComponent<Text>();
        Txt_WinNum = gameObject.transform.Find("BattleRes/Txt_WinNum").GetComponent<Text>();
        Scroll_View = gameObject.transform.Find("RoomList/Scroll_View").GetComponent<ScrollRect>();
        Scrollbar_Vertical = gameObject.transform.Find("RoomList/Scroll_View/Scrollbar_Vertical").GetComponent<Scrollbar>();
        Btn_CreatRoom = gameObject.transform.Find("RoomList/Btn_CreatRoom").GetComponent<Button>();
        Btn_Close = gameObject.transform.Find("RoomList/Btn_Close").GetComponent<Button>();
        Btn_Refresh = gameObject.transform.Find("RoomList/Btn_Refresh").GetComponent<Button>();
        roomItemPrefab = Resources.Load("UIPanel/RoomItem") as GameObject;
        grid = gameObject.transform.Find("RoomList/Scroll_View/Viewport/Content").gameObject;
        AddClicks();
    }

    private void AddClicks()
    {
        Btn_CreatRoom.onClick.AddListener(OnCreatRoomClick);
        Btn_Close.onClick.AddListener(OnCloseClick);
        Btn_Refresh.onClick.AddListener(OnRefreshClick);
    }

    private void SetBattleResult()
    {
        UserData data = facade.GetUserData();
        Txt_Name.text = data.UserName;
        Txt_Scene.text = string.Format("总场次：{0}", data.TotalName.ToString());
        Txt_WinNum.text = string.Format("胜利：{0}", data.WinCount.ToString());
    }

    private void LoadRoomItem(int count = 0)
    {
        //for (int i = 0; i < count; i++)
        //{
        //    var roomItem = Instantiate(roomItemPrefab);
        //    roomItem.transform.SetParent(grid.transform);
        //}

        var roomItem = Instantiate(roomItemPrefab);
        roomItem.transform.SetParent(grid.transform);
    }

    private void OnCreatRoomClick()
    {
        LoadRoomItem();
    }
    private void OnCloseClick()
    {
        PlayClickSound();
        uiMgr.PopPanel();
    }

    private void OnRefreshClick()
    {

    }


    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        SetBattleResult();
    }

    /// <summary>
    /// 界面暂停  表示的当前的界面的上一个界面(加载下一个界面)
    /// </summary>
    public override void OnPause()
    {
        base.OnPause();
    }

    /// <summary>
    /// 界面继续  表示的当前的界面的上一个界面(弹出上一个界面)
    /// </summary>
    public override void OnResume()
    {
        base.OnResume();
    }

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关系
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
    }

    //autoEnd
}
