using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	//public bool Play(PlayMode mode = PlayMode.StopSameLayer);
	//public bool Play(string animation, PlayMode mode = PlayMode.StopSameLayer);

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, -1, 0);
	}
}
