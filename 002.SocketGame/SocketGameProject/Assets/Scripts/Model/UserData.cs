using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public string UserName { get; private set; }
    public int TotalCount { get; private set; }
    public int WinCount { get; private set; }


    public UserData(string userName,int totalCount,int winCount)
    {
        UserName = userName;
        TotalCount = totalCount;
        WinCount = winCount;
    }
}
