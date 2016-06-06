using System;
using UnityEngine;
using System.Collections;
using Orkad.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.UI;

public class LobbyManager : NetworkLobbyManager
{
    public new static LobbyManager singleton;

    public event Action ClientConnectEvent;
    public event Action ClientDisconnectEvent;

    LobbyManager()
    {
        if(singleton == null)
            singleton = this;
    }

    public override void OnLobbyServerPlayersReady()
    {
        Debug.Log("LobbyManager : OnLobbyServerPlayersReady");
        bool allReady = true;
        int playerCount = 0;
        foreach (NetworkLobbyPlayer p in lobbySlots)
        {
            if (p == null)
                continue;
            if (!p.readyToBegin)
                allReady = false;
            playerCount++;
        }
        if (allReady && playerCount >= minPlayers)
        {
            base.OnLobbyServerPlayersReady();
        }
    }

    public override void OnLobbyClientConnect(NetworkConnection conn)
    {
        Debug.Log("LobbyManager : OnLobbyClientConnect");
        if (ClientConnectEvent != null) ClientConnectEvent.Invoke();
    }

    public override void OnLobbyClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("LobbyManager : OnClientDisconnect");
        if (ClientDisconnectEvent != null) ClientDisconnectEvent.Invoke();
    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        Debug.Log("LobbyManager : OnClientSceneChanged");
        base.OnClientSceneChanged(conn);
    }

    public override void OnLobbyClientExit()
    {
        Debug.Log("LobbyManager : OnLobbyClientExit");
        base.OnLobbyClientExit();
    }

    public void Host()
    {
        StartHost();
    }

    public void Join()
    {
        StartClient();
    }

    public void Exit()
    {
        StopHost();
    }
}
