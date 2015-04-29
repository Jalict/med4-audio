using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Tracker : MonoBehaviour {
    private Camera cam;
    public GameObject track;
    public Light dirLight;
    public GameObject soundController;

    private string filename;

    private bool isTracking;

    private StreamWriter file;
    private Texture2D shot;

	// Use this for initialization
	void Start () {

        cam = gameObject.GetComponent<Camera>();
        soundController = GameObject.Find("SoundController");

        filename = System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm");

        if(File.Exists(filename + ".txt")) {
            Debug.Log("SHIT EXIST");
            return;
        }
        file = File.CreateText(filename+".txt");

        StartTracking();

        StartCoroutine(GetInitialOverviewTexture());
	}

    IEnumerator Tracking()
    {
        while (isTracking)
        {
            file.WriteLine(track.transform.position.ToString());

            yield return new WaitForSeconds(0.5f);
        }
    }

    void StartTracking()
    {
        isTracking = true;

        StartCoroutine(Tracking());
    }

    void StopTracking()
    {
        isTracking = false;
        StopCoroutine(Tracking());
    }

    IEnumerator GetInitialOverviewTexture()
    {
        dirLight.enabled = true;

        yield return new WaitForEndOfFrame();

        cam.targetTexture = new RenderTexture(1024, 1024, 24);

        shot = new Texture2D(1024, 1024, TextureFormat.RGB24, false);

        cam.Render();

        RenderTexture.active = cam.targetTexture;

        shot.ReadPixels(new Rect(0, 0, 1024, 1024), 0, 0);

        cam.targetTexture = null;
        RenderTexture.active = null;

        dirLight.enabled = false;
    }

    void OnDestory()
    {
        StopCoroutine(Tracking());
        file.Close();

        byte[] bytes = shot.EncodeToPNG();
        System.IO.File.WriteAllBytes(filename + ".png", bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename + ".png"));
    }

    void OnApplicationQuit()
    {
        StopCoroutine(Tracking());

        file.WriteLine(soundController.GetComponent<SoundControl>().state);
        file.WriteLine(Time.realtimeSinceStartup);
        file.Close();

        byte[] bytes = shot.EncodeToPNG();
        System.IO.File.WriteAllBytes(filename + ".png", bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", Application.dataPath + filename + ".png"));
    }
}

