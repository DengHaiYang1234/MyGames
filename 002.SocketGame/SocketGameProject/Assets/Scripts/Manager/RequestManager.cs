using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade)
    {

    }


    private Dictionary<RequestCode, BaseRequest> requestDict = new Dictionary<RequestCode, BaseRequest>();

    public void AddRequest(RequestCode requestCode,BaseRequest request)
    {
        requestDict.Add(requestCode, request);
    }

    public void RemoveRequset(RequestCode requestCode)
    {
        requestDict.Remove(requestCode);
    }

    public void HandleReponse(RequestCode requestCode, string data)
    {
        BaseRequest request = requestDict.TryGetV<RequestCode, BaseRequest>(requestCode);
        if (request == null)
        {
            Debug.LogError("无法得到RequestCode[" + requestCode + "]对应的Request");
            return;
        }
        request.OnResponse(data);
    }
}
