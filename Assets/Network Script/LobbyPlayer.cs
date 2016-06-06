using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyPlayer : NetworkLobbyPlayer
{
    public static LobbyPlayer Me;
    [SyncVar(hook = "OnPlayerNameChange")]
    public string PlayerName;

    public string PlayerUiContainerName;
    public PlayerUI PlayerUiPrefab;
    private PlayerUI PlayerUiInstance;

    public override void OnStartLocalPlayer()       //2 - if local player
    {
        Me = this;
        CmdPlayerName(Data.PlayerName);
    }

    public override void OnClientEnterLobby()
    {
        GameObject container = GameObject.Find(PlayerUiContainerName);
        if (container)
        {
            PlayerUiInstance = Instantiate(PlayerUiPrefab);
            PlayerUiInstance.transform.SetParent(container.transform);
            PlayerUiInstance.Load(this);
        }
    }

    public override void OnClientReady(bool readyState)
    {
        if(PlayerUiInstance)
            PlayerUiInstance.SetReady(readyState);
    }

    void OnPlayerNameChange(string value)
    {
        name = "Player : " + value;
        if (PlayerUiInstance) PlayerUiInstance.PlayerNameText.text = value;
    }

    [Command]
    void CmdPlayerName(string value)
    {
        PlayerName = value;
    }

    void OnDestroy()
    {
        if (PlayerUiInstance)
            Destroy(PlayerUiInstance.gameObject);
    }
}
