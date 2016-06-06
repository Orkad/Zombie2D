using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
public class Character : NetworkBehaviour
{
    public new Rigidbody rigidbody { get { return GetComponent<Rigidbody>(); } }
    public static Character Me;
    public Weapon Weapon1;
    public Transform RightHand;
    public Transform LeftHand;
    public float Speed = 5f;
    public float maxVelocityChange = 10.0f;

    // Use this for initialization
    void Start ()
	{
	    if (isLocalPlayer)
	    {
            Me = this;
            var camera = FindObjectOfType<TopDownCamera>();
	        camera.target = transform;
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!isLocalPlayer)
	        return;


        
	    if (Input.GetButton("Fire1"))
	    {
            IUsable usable = RightHand.GetComponentInChildren<IUsable>();
            if (usable != null)
                usable.Use();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            CmdEquip(Weapon1.GetComponent<NetworkIdentity>().assetId);
        }
    }

    void FixedUpdate()
    {
        
        if (!isLocalPlayer)
            return;
        // Calculate how fast we should be moving
        var targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= Speed;

        // Apply a force that attempts to reach our target velocity
        var velocity = rigidbody.velocity;
        var velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = objectPos  - Input.mousePosition;
        transform.rotation = Quaternion.Euler(new Vector3(0,- Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90, 0));
    }

    [Command]
    void CmdEquip(NetworkHash128 assetId)
    {
        GameObject prefab;
        ClientScene.prefabs.TryGetValue(assetId, out prefab);
        if (!prefab)
            return;
        GameObject instance = Instantiate(prefab);
        NetworkServer.SpawnWithClientAuthority(instance, connectionToClient);
        RpcEquip(instance.GetComponent<NetworkIdentity>());
    }

    [ClientRpc]
    void RpcEquip(NetworkIdentity instance)
    {
        instance.transform.SetParent(RightHand,false);
    }
}
