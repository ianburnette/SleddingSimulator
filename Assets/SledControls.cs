using UnityEngine;
using System.Collections;

public class SledControls : MonoBehaviour {

	public float rotateSpeed, pushSpeed;
	float h, v;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		GetInput ();
		TurnSled (h);
		PushSled (v);
	}

	void GetInput(){
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
	}

	void TurnSled (float hInput){
		//rb.AddTorque (transform.up * hInput * rotateSpeed * Time.deltaTime);
		//rb.AddRelativeTorque (transform.up * hInput * rotateSpeed * Time.deltaTime);
		transform.Rotate (transform.up * hInput * rotateSpeed * Time.deltaTime);
	}

	void PushSled (float vInput){
		if (vInput > 0){
			rb.AddForce (transform.right * pushSpeed * vInput * Time.deltaTime);
        }
	}
}
