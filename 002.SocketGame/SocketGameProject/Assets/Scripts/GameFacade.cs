using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private UIManager uiMgr;
    private RequestManager reqMgr;
    private CamreaManager camMgr;
    private AudioMAnager audMgr;
    private PlayerManager playerMgr;
    private ClientManager clientMgr;

    private void Start()
    {
        InitManager();
    }

    private void InitManager()
    {
        uiMgr = new UIManager();
        reqMgr = new RequestManager();
        camMgr = new CamreaManager();
        audMgr = new AudioMAnager();
        playerMgr = new PlayerManager();
        clientMgr = new ClientManager();

        uiMgr.OnInit();
        reqMgr.OnInit();
        camMgr.OnInit();
        audMgr.OnInit();
        playerMgr.OnInit();
        clientMgr.OnInit();
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
