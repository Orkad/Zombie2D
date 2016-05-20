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
            LobbyPlayer.Me.readyToBegin = true;
            NotReadyButton.gameObject.SetActive(true);
            ReadyButton.interactable = false;
        });
        NotReadyButton.onClick.AddListener(() =>
        {
            LobbyPlayer.Me.readyToBegin = false;
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
        Debug.Log("OnLobbyServerPlayersReady");
        StartCoroutine(ReadyCoroutine());
    }

    IEnumerator ReadyCoroutine()
    {
        TimerText.gameObject.SetActive(true);
        for (int i = TimeToStart; i > 0; i--)
        {
            TimerText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

    }

    public override void OnLobbyClientConnect(NetworkConnection conn)
    {
        Debug.Log("OnLobbyClientConnect");
        MainMenu.Stack(LobbyMenu);
        Worker.Hide();
    }

    public override void OnLobbyClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("OnLobbyClientDisconnect");
    }

    public override void OnLobbyStartHost()
    {
        Debug.Log("OnLobbyStartHost");
    }

    public override void OnLobbyClientEnter()
    {
        Debug.Log("OnLobbyClientEnter");
    }

    public override void OnLobbyClientExit()
    {
        Debug.Log("OnLobbyClientExit");
    }

    public override void OnLobbyClientAddPlayerFailed()
    {
        Debug.Log("OnLobbyClientAddPlayerFailed");
    }

    public override void OnLobbyClientSceneChanged(NetworkConnection conn)
    {
        Debug.Log("OnLobbyClientSceneChanged");
    }

    public override void OnLobbyStartClient(NetworkClient lobbyClient)
    {
        Debug.Log("OnLobbyStartClient");
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
