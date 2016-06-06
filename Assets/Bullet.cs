using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class Bullet:NetworkBehaviour
{
    public float InitialForce = 5f;
    public float LifeTime = 2f;
    public float Damages;
    public int MaxBounce;
    public Dot DotOnHit;

    void Start()
    {
        if(isServer)
            GetComponent<Rigidbody>().AddForce(transform.forward * InitialForce);
    }

    [ServerCallback]
    void Update()
    {
        if (LifeTime < 0)
            NetworkServer.Destroy(gameObject);
        LifeTime -= Time.deltaTime;
    }

    [ServerCallback]
    void OnCollisionEnter(Collision other)
    {
        var otherDamageable = other.collider.GetComponentInChildren<IDamageable>();
        if (otherDamageable != null)
        {
            otherDamageable.Damage(Damages);
            if (DotOnHit != null)
                otherDamageable.gameObject.CopyComponent(DotOnHit);
        }
        else if (MaxBounce > 0)
            MaxBounce--;
        else
            Destroy(gameObject);
    }
}
