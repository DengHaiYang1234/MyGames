using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class GamePanel:BasePanel
{
    //auto
    private Text Txt_Timer = null;

    private int time = -1;
	
    public override void InitStart()
    {
        Txt_Timer = gameObject.transform.Find("Txt_Timer").GetComponent<Text>();
		AddClicks();
    }

    private void Update()
    {
        if (time > -1)
        {
            ShowTime(time);
            time = -1;
        }
    }

    private void AddClicks()
    {
        
    }

    public void ShowTimeSync(int time)
    {
        
        this.time = time;
    }

    public void ShowTime(int time)
    {
        Debug.LogError("time" + time);
        Txt_Timer.gameObject.SetActive(true);
        Txt_Timer.text = time.ToString();
        Txt_Timer.transform.localScale = Vector3.one;
        Color tempColor = Txt_Timer.color;
        tempColor.a = 1;
        Txt_Timer.color = tempColor;
        Txt_Timer.transform.DOScale(2, 0.5f).SetDelay(0.3f);
        Txt_Timer.DOFade(0, 0.3f).SetDelay(0.3f).OnComplete(() => Txt_Timer.gameObject.SetActive(false));
        facade.PlayNoramSound(AudioMAnager.Sound_Timer,1f,false);
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
            