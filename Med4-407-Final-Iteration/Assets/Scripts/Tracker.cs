using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Tracker : MonoBehaviour {
    private Camera cam;
    public GameObject track;
    public Light dirLight;
    public SoundControl sc;
    public PaperScript ps;

    private string filename;

    private bool isTracking;

    private StreamWriter file;
    private Texture2D shot;
    private float timestamp;

    private float t1 = 0, t2 = 0, t3 = 0, t4 = 0;


	// Use this for initialization
	void Start () {
        cam = gameObject.GetComponent<Camera>();

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
        while (true)
        {
            if (Input.anyKeyDown)
                break;

            yield return new WaitForFixedUpdate();
        }

        Debug.Log("STARTED TRACKING");
        timestamp = Time.timeSinceLevelLoad;

        while (isTracking)
        {
            file.WriteLine(track.transform.position.ToString());

            switch (ps.curStage)
            {
                case 2:
                    if (t1 == 0)
                    {
                        t1 = Time.timeSinceLevelLoad;
                        break;
                    }
                    continue;
                case 3:
                    if (t2 == 0)
                    {
                        t2 = Time.timeSinceLevelLoad;
                        break;
                    }
                    continue;
                case 4:
                    if (t3 == 0)
                    {
                        t3 = Time.timeSinceLevelLoad;
                        break;
                    }
                    continue;
                case 5:
                    if (t4 == 0)
                    {
                        t4 = Time.timeSinceLevelLoad;
                        break;
                    }
                    continue;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void StartTracking()
    {
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

        // DO REST HERE:
        // http://answers.unity3d.com/questions/22954/how-to-save-a-picture-take-screenshot-from-a-camer.html
    }

    void OnApplicationQuit()
    {
        StopCoroutine(Tracking());
        file.WriteLine("" + sc.state);
        file.WriteLine("" + (Time.timeSinceLevelLoad - timestamp));
        file.WriteLine("" + (timestamp - t1));
        file.WriteLine("" + (t1 - t2));
        file.WriteLine("" + (t2 - t3));
        file.WriteLine("" + (t3 - t4));
        file.Close();

        byte[] bytes = shot.EncodeToPNG();
        System.IO.File.WriteAllBytes(filename + ".png", bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename + ".png"));
    }
}

