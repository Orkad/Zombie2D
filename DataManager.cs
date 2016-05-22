using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public InputField PlayerNameInput;

    void Start()
    {
        if (PlayerNameInput != null)
        {
            PlayerNameInput.onEndEdit.AddListener(playerName => Data.PlayerName.Set(playerName));
            PlayerNameInput.text = Data.PlayerName;
        }
    }
}
