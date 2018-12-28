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

    private bool isSpaw = false;

    private GameObject playerSyncReuest;

    private GameObject remoteRoleObj;

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

    public override void Update()
    {
        if (isSpaw)
        {
            SpawnRoles();
            isSpaw = false;
        }
    }
    
    public void SpawnRoles()
    {
        foreach (var rd in roleDataDic.Values)
        {
            var obj = GameObject.Instantiate(rd.RolePrefab, rd.SpawnPosition, Quaternion.identity);
            if (rd.RoleType == currRoleType)
            {
                currentRoleObj = obj;
            }
            else
            {
                remoteRoleObj = obj;
            }
        }
    }

    public void SpawnRolesSync()
    {
        isSpaw = true;
    }


    public void AddControllerScript()
    {
        currentRoleObj.AddComponent<PlayerMove>();
        var playerAttack = currentRoleObj.AddComponent<PlayerAttack>();
        RoleData rd = GetRoleDataByRoleType(currRoleType);
        playerAttack.arrowPreafab = rd.ArrowPrefab;
    }

    public RoleData GetRoleDataByRoleType(RoleType roleType)
    {
        RoleData rd = null;
        roleDataDic.TryGetValue(roleType, out rd);
        return rd;
    }

    public void CreatSyncRequest()
    {
        playerSyncReuest = new GameObject("playerSyncRequest");
        //设置本地客户端及另一个客户端的Obj
        playerSyncReuest.AddComponent<MoveRequest>()
            .SetLocalPlayer(currentRoleObj.transform, currentRoleObj.GetComponent<PlayerMove>())
            .SetRemotePlayer(remoteRoleObj.transform);

    }
}
