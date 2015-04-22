using UnityEngine;
using System.Collections;
using TBE_3DCore;

public class Footsteps : MonoBehaviour {
	public TBE_Source src;
	public GameObject obj;



	// Use this for initialization
	void Start () {
		src = gameObject.GetComponent<TBE_Source>();

		src.mute = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(obj.GetComponent<CharacterController>().velocity.magnitude > 0.1f) {
			src.mute = false;
		} else {
			src.mute = true;
		}
	}

}
