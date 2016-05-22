using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyPlayer : NetworkLobbyPlayer
{
    public static LobbyPlayer Me;
    [SyncVar]
    public string PlayerName;

    public Color MyColor;
    public Color OtherColor;

    public Text PlayerNameText;
    public Image PlayerColorImage;
    public Image ImageToShowWhenReady;

    void Start()
    {
        ImageToShowWhenReady.enabled = readyToBegin;
        if (isLocalPlayer)
        {
            Me = this;
            CmdSetPlayerName(Data.PlayerName);
            PlayerColorImage.color = MyColor;
        }
        else
        {
            PlayerColorImage.color = OtherColor;
        }
    }

    void Update()
    {
        PlayerNameText.text = name = PlayerName;
    }

    public override void OnClientReady(bool readyState)
    {
        Debug.Log("LobbyPlayer : OnClientReady");
        ImageToShowWhenReady.enabled = readyState;
    }

    [Command]
    void CmdSetPlayerName(string value)
    {
        PlayerName = value;
    }
}
