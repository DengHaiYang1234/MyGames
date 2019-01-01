using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class GameOverRequest : BaseRequest
{
    public override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.GameOver;
        base.Awake();
    }

    public override void OnResponse(string data)
    {
        ReturnCode returnCode = (ReturnCode) int.Parse(data);
        base.OnResponse(data);
    }

}
