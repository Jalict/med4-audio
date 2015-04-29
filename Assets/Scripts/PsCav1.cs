using UnityEngine;
using System.Collections;

public class PsCav1 : MonoBehaviour {
	private int curStage;
	public GameObject objW;
	public GameObject objB;
	public GameObject objF;
	public Renderer rend;
	public Texture texture1;
	public Texture texture2;
	public Texture texture3;
	public AudioClip sound;
	
	
	// Use this for initialization
	void Start () {
		curStage = 1;
		rend.material.mainTexture = texture1;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(curStage == 1 && Vector3.Distance(objW.transform.position, gameObject.transform.position) < 10) {
			rend.material.mainTexture = texture2;
			curStage ++;
			AudioSource.PlayClipAtPoint(sound, transform.position);
		}
		if(curStage == 2 && Vector3.Distance(objF.transform.position, gameObject.transform.position) < 10) {
			rend.material.mainTexture = texture3;
			curStage ++;
			AudioSource.PlayClipAtPoint(sound, transform.position);
		}
		if (curStage == 3 && Vector3.Distance (objB.transform.position, gameObject.transform.position) < 10){
			StartCoroutine (ExitApp());
			AudioSource.PlayClipAtPoint(sound, transform.position);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	IEnumerator ExitApp(){
		yield return new WaitForSeconds(5);
		Application.Quit ();
	}
}
