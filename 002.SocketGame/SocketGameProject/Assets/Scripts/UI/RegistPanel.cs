using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class RegistPanel : BasePanel
{
    //auto
    private InputField Input_UserName = null;
    private Text Txt_UserNamePlaceholder = null;
    private Text Txt_UserNameText = null;
    private InputField Input_PassWord = null;
    private Text Txt_PassWordPlaceholder = null;
    private Text Txt_PassWordText = null;
    private Button Btn_Register = null;
    private InputField Input_RePassWord = null;
    private Text Txt_RePassWordPlaceholder = null;
    private Text Txt_RePassWordText = null;
    private Button Btn_Close = null;

    public void Start()
    {
        Input_UserName = gameObject.transform.Find("UserName/Input_UserName").GetComponent<InputField>();
        Txt_UserNamePlaceholder = gameObject.transform.Find("UserName/Input_UserName/Txt_UserNamePlaceholder").GetComponent<Text>();
        Txt_UserNameText = gameObject.transform.Find("UserName/Input_UserName/Txt_UserNameText").GetComponent<Text>();
        Input_PassWord = gameObject.transform.Find("PassWord/Input_PassWord").GetComponent<InputField>();
        Txt_PassWordPlaceholder = gameObject.transform.Find("PassWord/Input_PassWord/Txt_PassWordPlaceholder").GetComponent<Text>();
        Txt_PassWordText = gameObject.transform.Find("PassWord/Input_PassWord/Txt_PassWordText").GetComponent<Text>();
        Btn_Register = gameObject.transform.Find("Btn_Register").GetComponent<Button>();
        Input_RePassWord = gameObject.transform.Find("RePassWord/Input_RePassWord").GetComponent<InputField>();
        Txt_RePassWordPlaceholder = gameObject.transform.Find("RePassWord/Input_RePassWord/Txt_RePassWordPlaceholder").GetComponent<Text>();
        Txt_RePassWordText = gameObject.transform.Find("RePassWord/Input_RePassWord/Txt_RePassWordText").GetComponent<Text>();
        Btn_Close = gameObject.transform.Find("Btn_Close").GetComponent<Button>();

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
