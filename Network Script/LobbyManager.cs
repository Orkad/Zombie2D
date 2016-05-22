using System;
using UnityEngine;
using System.Collections;
using Orkad.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.UI;

public class LobbyManager : NetworkLobbyManager
{
    [Space]

    public Menu MainMenu;
    public Menu LobbyMenu;
    public Fader Worker;
    public Button JoinButton;
    public Button HostButton;
    public Button LeaveButton;
    public Button ReadyButton;
    public Button NotReadyButton;
    public Text TimerText;
    public int TimeToStart = 5;

    void Start()
    {
        JoinButton.onClick.AddListener(Join);
        HostButton.onClick.AddListener(Host);
        LeaveButton.onClick.AddListener(Exit);
        NotReadyButton.gameObject.SetActive(false);
        ReadyButton.onClick.AddListener(() =>
        {
            LobbyPlayer.Me.SendReadyToBeginMessage();
            NotReadyButton.gameObject.SetActive(true);
            ReadyButton.interactable = false;
        });
        NotReadyButton.onClick.AddListener(() =>
        {
            LobbyPlayer.Me.SendNotReadyToBeginMessage();
            NotReadyButton.gameObject.SetActive(false);
            ReadyButton.interactable = true;
        });
        TimerText.gameObject.SetActive(false);
    }

    void Update()
    {

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
            StartCoroutine("ReadyCoroutine");
            TimerText.gameObject.SetActive(true);
        }
        else
        {
            StopCoroutine("ReadyCoroutine");
            TimerText.gameObject.SetActive(false);
        }
    }

    IEnumerator ReadyCoroutine()
    {
        for (int i = TimeToStart; i > 0; i--)
        {
            TimerText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        TimerText.text = "Loading";
        yield return new WaitForSeconds(1f);
        base.OnLobbyServerPlayersReady();
    }

    public override void OnLobbyClientConnect(NetworkConnection conn)
    {
        Debug.Log("LobbyManager : OnLobbyClientConnect");
        MainMenu.Stack(LobbyMenu);
        Worker.Hide();
    }

    private void Host()
    {
        client = StartHost();
    }

    private void Join()
    {
        client = StartClient();
    }

    private void Exit()
    {
        StopHost();
    }
}
