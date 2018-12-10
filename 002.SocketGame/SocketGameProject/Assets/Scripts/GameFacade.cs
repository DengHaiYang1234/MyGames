﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class GameFacade : MonoBehaviour
{
    private static GameFacade _instace;

    public static GameFacade Instance
    {
        get { return _instace; }
    }
    
    private UIManager uiMgr;
    private RequestManager reqMgr;
    private CamreaManager camMgr;
    private AudioMAnager audMgr;
    private PlayerManager playerMgr;
    private ClientManager clientMgr;

    private void Awake()
    {
        if (_instace != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instace = this;
    }

    private void Start()
    {
        InitManager();
    }

    

    private void InitManager()
    {
        uiMgr = new UIManager(this);
        reqMgr = new RequestManager(this);
        camMgr = new CamreaManager(this);
        audMgr = new AudioMAnager(this);
        playerMgr = new PlayerManager(this);
        clientMgr = new ClientManager(this);

        uiMgr.OnInit();
        reqMgr.OnInit();
        camMgr.OnInit();
        audMgr.OnInit();
        playerMgr.OnInit();
        clientMgr.OnInit();
    }

    public void AddRequest(ActionCode actionCode, BaseRequest requset)
    {
        reqMgr.AddRequest(actionCode, requset);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        reqMgr.RemoveRequset(actionCode);
    }

    public void HandleReponse(ActionCode actionCode, string data)
    {
        reqMgr.HandleReponse(actionCode, data);
    }

    public void ShowMessage(string msg)
    {
        uiMgr.ShowMessage(msg);
    }

    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        clientMgr.SendRequest(requestCode, actionCode, data);
    }


    private void OnDestroyManager()
    {
        uiMgr.OnDestroy();
        reqMgr.OnDestroy();
        camMgr.OnDestroy();
        audMgr.OnDestroy();
        playerMgr.OnDestroy();
        clientMgr.OnDestroy();
    }




    private void OnDestroy()
    {
        OnDestroyManager();
    }

}
