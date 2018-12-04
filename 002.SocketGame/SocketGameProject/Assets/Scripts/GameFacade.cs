using System.Collections;
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

    public void AddRequest(RequestCode requestCode,BaseRequest requset)
    {
        reqMgr.AddRequest(requestCode, requset);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        reqMgr.RemoveRequset(requestCode);
    }

    public void HandleReponse(RequestCode requestCode, string data)
    {
        reqMgr.HandleReponse(requestCode, data);
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
