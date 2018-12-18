using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class CreatRoomRequest : BaseRequest
{
    private RoomInfoPanel roomInfoPanel = null;
    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.CreatRoom;
        roomInfoPanel = GetComponent<RoomInfoPanel>();
        base.Awake();
    }

    public override void SendRequest()
    {
        base.SendRequest("r");
    }

    public override void OnResponse(string data)
    {
        ReturnCode returnCode = (ReturnCode) int.Parse(data);
        if (returnCode == ReturnCode.Success)
        {
            UserData ud = facade.GetUserData();
            roomInfoPanel.SetLocalPlayerResSync();
        }
    }

}
