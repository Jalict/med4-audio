using UnityEngine;
using System.Collections;

public class ToggleMovement : MonoBehaviour {
    public OtherMovementSystem other;

    public Material skybox1;
    public Material skybox2;
    public Material skybox3;

    public Light light;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        light.intensity = 0.20f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
            other.enabled = !other.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RenderSettings.skybox = skybox1;
            light.intensity = 0.05f;;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RenderSettings.skybox = skybox2;
            light.intensity = 0.125f;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RenderSettings.skybox = skybox3;
            light.intensity = 0.20f;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            light.intensity = 1f;
        }
	}
}
