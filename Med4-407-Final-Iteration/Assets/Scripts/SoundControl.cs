using UnityEngine;
using System.Collections;
using TBE_3DCore;

public class SoundControl : MonoBehaviour {
	public static SoundControl instance;
	public int state; // 0 = Control, 1 = Amplitude


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

		GameObject[] soundsObjs = GameObject.FindGameObjectsWithTag("SoundChange");

		foreach(GameObject obj in soundsObjs) {
			if(state == 1) {
				obj.GetComponent<TBE_Source>().minimumDistance = 9999;
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
			StartCoroutine(GoThroughTags());
		}
		if(Input.GetKeyDown(KeyCode.K)) {
			Application.LoadLevel(1);
		}
	}
}
