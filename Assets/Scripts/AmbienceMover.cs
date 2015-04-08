using UnityEngine;
using System.Collections;

public class AmbienceMover : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 t = player.transform.position;
        t.y += 0.1f;
        t.z += 0.38f;
        transform.position = t;

	}
}
