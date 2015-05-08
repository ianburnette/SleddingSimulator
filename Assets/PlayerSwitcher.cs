using UnityEngine;
using System.Collections;

public class PlayerSwitcher : MonoBehaviour {

	public bool onSled, crashed, haveSled;

	public GameObject onSledPlayer, onFootPlayer, sledCamera;
	public float switchCooldownTime;
	bool cantSwitch = false;
	public Vector3 onFootPlayerOffset, onSledPlayerOffset, sledCameraOffset;

	// Use this for initialization
	void Start () {
		sledCameraOffset = onSledPlayer.transform.GetChild (1).position;
	}
	
	// Update is called once per frame
	void Update () {
		CheckForSwitch ();
	}

	void CheckForSwitch(){
		if (Input.GetButtonDown ("Fire1") && !cantSwitch) {
			Switch ();
		}
	}

	void Switch(){
		if (onSled) {
			SetOnFootPlayerPosition (onSledPlayer.transform);
			onSledPlayer.SetActive (false);
			onFootPlayer.SetActive (true);
			onSled = false;
		} else if (crashed) {
			SetOnFootPlayerPosition (sledCamera.transform);
			sledCamera.SetActive (false);
			onFootPlayer.SetActive (true);
			onSled = true;
		} else {
			onSledPlayer.SetActive (true);
			onFootPlayer.SetActive (false);
			onSled = true;
			SetOnSledPlayerPosition ();
		}
		cantSwitch = true;
		Invoke ("ResetSwitchTime", switchCooldownTime);
	}

	void SetOnFootPlayerPosition(Transform locationToPlace){
		onFootPlayer.transform.position = locationToPlace.position + onFootPlayerOffset;
	}

	void SetOnSledPlayerPosition(){
		
	}

	void ResetSwitchTime(){
		cantSwitch = false;
	}
}
