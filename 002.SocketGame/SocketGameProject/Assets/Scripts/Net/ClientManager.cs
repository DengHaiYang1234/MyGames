using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using Common;

/// <summary>
/// 与服务器的socket连接
/// </summary>
public class ClientManager :BaseManager
{

    public ClientManager(GameFacade facade) : base(facade)
    {

    }
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket clientSocket;

    private Message msg = new Message();

    public override void OnInit()
    {
        base.OnInit(); //父类方法执行


        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
            Start();
        }
        catch(Exception e)
        {
            Debug.LogWarning("无法连接服务端。请检查网络." + e);
        }
    }

    private void Start()
    {
        clientSocket.BeginReceive(msg.Data,msg.StartIndex,msg.RemainSize, SocketFlags.None,ReceiveCallBack,null);
    }

    private void ReceiveCallBack(IAsyncResult ar)
    {
        try
        {
            int count = clientSocket.EndReceive(ar);
            msg.ReadMessage(count,OnProcessDataCallBack);
            Start();
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void OnProcessDataCallBack(RequestCode requsetCode,string data)
    {
        GameFacade.Instance.HandleReponse(requsetCode, data);
    }

    public void SendRequest(RequestCode requestCode,ActionCode actionCode,string data)
    {
        byte[] bytes = Message.PackData(requestCode, actionCode, data);
        clientSocket.Send(bytes);
    }





    public override void OnDestroy()
    {
        base.OnDestroy();
        try
        {
            clientSocket.Close();
        }
        catch (Exception e)
        {
            Debug.LogWarning("无法关闭跟服务器端的连接:" + e);
        }
    }


}
