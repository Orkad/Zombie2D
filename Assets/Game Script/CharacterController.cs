using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : NetworkBehaviour {
	public Rigidbody2D rb2D { get { return GetComponent<Rigidbody2D> (); } }
	public float speed = 5f;

    void Update()
    {
        if(rb2D.velocity.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if(rb2D.velocity.x > 0)
            GetComponent<SpriteRenderer>().flipX = false;
    }

	void FixedUpdate()
	{
        if(isLocalPlayer)
		    rb2D.velocity = new Vector2(Input.GetAxis("Horizontal")* speed,Input.GetAxis("Vertical")* speed);
	}
}
