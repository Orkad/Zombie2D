using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkIdentity))]
public class TestSync : MonoBehaviour
{
    private bool isServer;
    void Start()
    {
        isServer = GetComponent<NetworkIdentity>().isServer;
        GetComponent<Rigidbody>().velocity = new Vector3(30, 0, 0);
    }

    void FixedUpdate()
    {
        if (isServer)
        {
            if(transform.position.x < -10)
                GetComponent<Rigidbody>().velocity = new Vector3(30,0,0);
            else if(transform.position.x > 10)
                GetComponent<Rigidbody>().velocity = new Vector3(-30, 0, 0);
        }
        
    }
}
