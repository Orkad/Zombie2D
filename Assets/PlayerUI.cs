using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    [Space]
    [Header("UI Reference")]
    public Text PlayerNameText;
    public Image PlayerColorImage;
    public Image CheckImage;

    public Color LocalColor;
    public Color OtherColor;
	public void Load(LobbyPlayer player)
    {
        PlayerColorImage.color = player.isLocalPlayer ? LocalColor : OtherColor;
        PlayerNameText.text = player.PlayerName;
        CheckImage.enabled = player.readyToBegin;
    }

    public void SetReady(bool ready)
    {
        CheckImage.enabled = ready;
    }
}
