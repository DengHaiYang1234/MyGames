using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class GamePanel : BasePanel
{
    //---------------------------------------注意以下会完成变量初始化，刷新时会更新变量--------------------------------------------

    //auto
    private Text Txt_Timer = null;
    private Button Btn_Success = null;
    private Button Btn_Fail = null;

    public override void InitStart()
    {
        Txt_Timer = gameObject.transform.Find("Txt_Timer").GetComponent<Text>();
        Btn_Success = gameObject.transform.Find("Btn_Success").GetComponent<Button>();
        Btn_Fail = gameObject.transform.Find("Btn_Fail").GetComponent<Button>();
        AddClicks();
    }

    private void AddClicks()
    {
        Btn_Success.onClick.AddListener(OnSuccessClick);
        Btn_Fail.onClick.AddListener(OnFailClick);

    }

    //---------------------------------------注意以上会完成变量初始化，刷新时会更新变量--------------------------------------------

    //defaultFcuntion

    private void OnSuccessClick()
    {
        Debug.Log("123");
    }
    private void OnFailClick()
    {
        Debug.Log("234");
    }


    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
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
