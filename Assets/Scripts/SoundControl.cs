using UnityEngine;
using System.Collections;
using TBE_3DCore;

public class SoundControl : MonoBehaviour {
	public static SoundControl instance;
	public int state; // 0 = Control, 1 = Amplitude, 2 = Doppler, 3 = Reverb


	// Use this for initialization
	void Start () {
		state = 0;
	}

	void AmplitudeChange(GameObject[] obj) {
	}

	void Awake() {
		if(instance)
			DestroyImmediate(gameObject);
		else {
			instance = this;
			DontDestroyOnLoad(instance);
		}

		StartCoroutine(GoThroughTags());
	}

	public IEnumerator GoThroughTags() {
		yield return new WaitForEndOfFrame();

		GameObject[] soundsObjs = GameObject.FindGameObjectsWithTag("soundChange");

		foreach(GameObject obj in soundsObjs) {
			if(state == 1) {
				//obj.GetComponent<TBE_Source>()
			} else if(state == 2) {
				//obj.GetComponent<TBE_Source>()
			} else if(state == 3) {
				//obj.GetComponent<TBE_Source>()

			}
		}
	}

	public void StartIterator() {
		StartCoroutine(GoThroughTags());
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			state = 1;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			state = 2;
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			state = 3;
		}
	}
}
