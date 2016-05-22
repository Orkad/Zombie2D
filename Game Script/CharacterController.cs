using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour {
	public Rigidbody2D rb2D { get { return GetComponent<Rigidbody2D> (); } }
	public float speed = 50f;



	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
	}

	void FixedUpdate()
	{
		rb2D.velocity = new Vector2(Input.GetAxis("Horizontal")* speed,Input.GetAxis("Vertical")* speed);
	}
}
