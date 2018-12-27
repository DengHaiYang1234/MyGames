using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PlayerManager : BaseManager
{
    private UserData userData;

    private Dictionary<RoleType, RoleData> roleDataDic = new Dictionary<RoleType, RoleData>();

    private Transform rolePositons;

    private RoleType currRoleType;//当前客户端的角色类型

    private GameObject currentRoleObj; //当前客户端的角色Obj

    public GameObject GetCurrentRoleObj()
    {
        return currentRoleObj;
    }

    public void SetCurrentRoleType(RoleType rt)
    {
        currRoleType = rt;
    }

    public override void OnInit()
    {
        rolePositons = GameObject.Find("RolePositon").transform;
        InitRoleDataDic();

    }

    public PlayerManager(GameFacade facade) : base(facade)
    {

    }

    public UserData UserData
    {
        set { userData = value; }
        get { return userData; }
    }


    private void InitRoleDataDic()
    {
        roleDataDic.Add(RoleType.Blue,new RoleData(RoleType.Blue, "Prefabs/Hunter_BLUE", "Prefabs/Arrow_BLUE", rolePositons.Find("PosPosition1").transform));
        roleDataDic.Add(RoleType.Red, new RoleData(RoleType.Red, "Prefabs/Hunter_RED", "Prefabs/Arrow_RED", rolePositons.Find("PosPosition2").transform));
    }

    private void SpawnRoles()
    {
        foreach (var rd in roleDataDic.Values)
        {
            var obj = GameObject.Instantiate(rd.RolePrefab, rd.SpawnPosition, Quaternion.identity);
            if (rd.RoleType == currRoleType)
            {
                currentRoleObj = obj;
            }
        }
    }
}
