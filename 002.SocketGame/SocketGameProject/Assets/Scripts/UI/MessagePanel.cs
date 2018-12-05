﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MessagePanel : BasePanel
{
    private Text text;
    private float showTime = 1f;

    public override void OnEnter()
    {
        base.OnEnter();
        text = GetComponent<Text>();
        text.enabled = false;
        uiMgr.MapingPanelByName<MessagePanel>(UIPanelType.Message, this);
    }



    public void ShowMessage(string msg)
    {
        text.text = msg;
        text.enabled = true;
        Invoke("Hide", showTime);
    }

    private void Hide()
    {
        text.CrossFadeAlpha(0, 1, false);
    }

}
