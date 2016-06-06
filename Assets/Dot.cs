using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(IDamageable))]
public class Dot:NetworkBehaviour
{
    private IDamageable _damageable;
    [SyncVar] public float Dps;
    [SyncVar] public float Ttl;

    [ServerCallback]
    void Start()
    {
        _damageable = GetComponent<IDamageable>();
    }

    [ServerCallback]
    void Update()
    {
        if(Ttl < 0f)
            Destroy(this);
        _damageable.Damage(Dps*Time.deltaTime);
    }
}
