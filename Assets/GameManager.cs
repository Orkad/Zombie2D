using UnityEngine;
using System.Collections;
using Completed;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Player = Completed.Player;

public class GameManager : MonoBehaviour
{

    public Button ExitButton;
    public Text ClientOrServerText;
    public ProgressBar PlayerHealthBar;

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

    void Update()
    {
        if (PlayerHealthBar)
        {
            PlayerHealthBar.maxValue = Character.Me.GetComponent<Health>().MaxHealth;
            PlayerHealthBar.value = Character.Me.GetComponent<Health>().CurrentHealth;
            PlayerHealthBar.minValue = 0;
        }
    }
}
