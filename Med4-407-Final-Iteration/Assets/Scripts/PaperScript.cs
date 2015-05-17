using UnityEngine;
using System.Collections;

public class PaperScript : MonoBehaviour {
	public int curStage;
	public GameObject objW;
	public GameObject objB;
	public GameObject objF;
	public GameObject objT;
	public Renderer rend;
	public Texture texture1;
	public Texture texture2;
	public Texture texture3;
	public Texture texture4;
	public Texture texture5;
	public AudioClip sound;

	private bool isFinished;
	
	// Use this for initialization
	void Start () {
		curStage = 1;
		rend.material.mainTexture = texture1;
		isFinished = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(curStage == 1 && Vector3.Distance (objF.transform.position, gameObject.transform.position) < 10) {
			rend.material.mainTexture = texture2;
			curStage ++;
			AudioSource.PlayClipAtPoint(sound, transform.position);
		}
		if(curStage == 2 && Vector3.Distance (objT.transform.position, gameObject.transform.position) < 10) {
			rend.material.mainTexture = texture3;
			curStage ++;
			AudioSource.PlayClipAtPoint(sound, transform.position);
		}
		if(curStage == 3 && Vector3.Distance (objB.transform.position, gameObject.transform.position) < 10) {
			rend.material.mainTexture = texture4;
			curStage ++;
			AudioSource.PlayClipAtPoint(sound, transform.position);
		}
		if (curStage == 4 && Vector3.Distance (objW.transform.position, gameObject.transform.position) < 10 && !isFinished){
			rend.material.mainTexture = texture5;
			AudioSource.PlayClipAtPoint(sound, transform.position);
            curStage++;
			StartCoroutine (ExitApp());
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	
	IEnumerator ExitApp(){
		isFinished = true;
		yield return new WaitForSeconds(5);
		Application.Quit ();
	}
}