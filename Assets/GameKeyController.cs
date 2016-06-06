using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameKeyController : MonoBehaviour
{
    public event Action UseEvent;
    public KeyCode UseKey;


    void Update()
    {
        if(Input.GetKeyDown(UseKey))
            if (UseEvent != null) UseEvent.Invoke();
    }
}
