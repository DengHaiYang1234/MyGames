using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class BaseRequest : MonoBehaviour
{
    protected RequestCode requestCode = RequestCode.None;

    protected ActionCode actionCode = ActionCode.Node;

    protected GameFacade facade;
    
    /// <summary>
    /// 有派生类重写
    /// </summary>
    public virtual void Awake()
    {
        facade = GameFacade.Instance;
        GameFacade.Instance.AddRequest(actionCode, this);
    }

    protected void SendRequest(string data)
    {
        facade.SendRequest(requestCode, actionCode, data);
    }

    public virtual void SendRequest()
    {
        
    }

    /// <summary>
    /// 由子类重写    服务器消息返回结果
    /// </summary>
    /// <param name="data"></param>
    public virtual void OnResponse(string data)
    {
        
    }

    public virtual void OnDestroy()
    {
        GameFacade.Instance.RemoveRequest(actionCode);
    }

}
