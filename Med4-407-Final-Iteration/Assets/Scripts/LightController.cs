using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        gameObject.GetComponent<Light>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
            gameObject.GetComponent<Light>().enabled = !gameObject.GetComponent<Light>().enabled;
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 170, 30), "Press L to Toggle Night");
    }
}
