using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SledCrashDetection : MonoBehaviour {

	public Text velocityText;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		velocityText.text = "Current Magnitude: " + rb.velocity.magnitude;
	}
}
