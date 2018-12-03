using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;

/// <summary>
/// 与服务器的socket连接
/// </summary>
public class ClientManager :BaseManager
{
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket clientSocket;

    public override void OnInit()
    {
        base.OnInit(); //父类方法执行


        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
        }
        catch(Exception e)
        {
            Debug.LogWarning("无法连接服务端。请检查网络." + e);
        }
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
