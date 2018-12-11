using UnityEngine;
using System.Collections;

public class BasePanel : MonoBehaviour
{
    protected UIManager uiMgr;
    private GameFacade facade;

    public UIManager UIMgr
    {
        set { uiMgr = value; }
    }

    public GameFacade Facade
    {
        set { facade = value; }
    }

    protected void PlayClickSound()
    {
        facade.PlayNoramSound(AudioMAnager.Sound_ButtonClick,1f,false);
    }

    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public virtual void OnEnter()
    {

    }

    /// <summary>
    /// 界面暂停  表示的当前的界面的上一个界面(加载下一个界面)
    /// </summary>
    public virtual void OnPause()
    {

    }

    /// <summary>
    /// 界面继续  表示的当前的界面的上一个界面(弹出上一个界面)
    /// </summary>
    public virtual void OnResume()
    {

    }

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关系
    /// </summary>
    public virtual void OnExit()
    {

    }
}
