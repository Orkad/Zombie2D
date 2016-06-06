using UnityEngine;
using System.Collections;
using Orkad.UI;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    [Space]
    [Header("UI Reference")]
    public Menu MainMenu;
    public Menu LobbyMenu;
    public Fader Worker;
    public Button JoinButton;
    public Button HostButton;
    public Button LeaveButton;
    public Button ReadyButton;
    public Button NotReadyButton;
    public RectTransform PlayerUiContainer;

    [Space]
    [Header("Prefabs")]
    public PlayerUI PlayerUiPrefab;


    private LobbyManager lobbyManager;

    public void Start()
    {
        lobbyManager = LobbyManager.singleton;
        if (JoinButton) JoinButton.onClick.AddListener(() => lobbyManager.StartClient());
        if (HostButton) HostButton.onClick.AddListener(() => lobbyManager.StartHost());
        if (LeaveButton) LeaveButton.onClick.AddListener(() => lobbyManager.StopHost());
        if (NotReadyButton)
        {
            NotReadyButton.gameObject.SetActive(false);
            NotReadyButton.onClick.AddListener(() =>
            {
                LobbyPlayer.Me.SendNotReadyToBeginMessage();
                NotReadyButton.gameObject.SetActive(false);
                ReadyButton.interactable = true;
            });
        }
        if (ReadyButton)
        {
            ReadyButton.onClick.AddListener(() =>
            {
                LobbyPlayer.Me.SendReadyToBeginMessage();
                NotReadyButton.gameObject.SetActive(true);
                ReadyButton.interactable = false;
            });
        }

        lobbyManager.ClientConnectEvent += OnClientConnect;
        lobbyManager.ClientDisconnectEvent += OnClientDisconnect;
    }

    private void OnClientDisconnect()
    {
        
    }

    private void OnClientConnect()
    {
        MainMenu.Stack(LobbyMenu);
        Worker.Hide();
    }
}
