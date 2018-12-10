using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class LoginRequest : BaseRequest
{
    private LoginPanel loginPanel;

    public override void Awake()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
        loginPanel = GetComponent<LoginPanel>();
        base.Awake();
    }
    
    public void SendRequest(string userName,string password)
    {
        string data = userName + "," + password;
        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {
        ReturnCode returnCode = (ReturnCode)int.Parse(data);
        loginPanel.OnLoginReponse(returnCode);
    }

}
