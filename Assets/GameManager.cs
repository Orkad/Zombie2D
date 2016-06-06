using UnityEngine;
using System.Collections;
using Completed;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Button ExitButton;
    public Text ClientOrServerText;

    void Start()
    {
        if (!NetworkClient.active)
        {
            SceneManager.LoadScene(0);
            return;
        }  
        if(ExitButton)ExitButton.onClick.AddListener(NetworkManager.singleton.StopHost);
        if (ClientOrServerText) ClientOrServerText.text = NetworkServer.active ? "Server" : "Client";
    }

}
