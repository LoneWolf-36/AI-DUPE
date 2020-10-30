using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR_RenderCamera : MonoBehaviour
{
    public GameObject player;
    public Rigidbody Rb;
    Camera cam;
    public int resWidth = 256;
    public int resHeight = 256;
    public static string FN;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        InvokeRepeating("Snap", 1.0f, 0.05f);
    }

    // Update is called once per frame
    public void Snap()
    {
        Texture2D camtex = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        cam.Render();
        RenderTexture.active = cam.targetTexture;
        camtex.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        camtex.Apply();
        byte[] bytes = camtex.EncodeToPNG();
        string FileName = IMG_NAME();
        FN = FileName;
        System.IO.File.WriteAllBytes(FileName, bytes);
        Rb = player.GetComponent<Rigidbody>();
        

    }

    public string IMG_NAME()
    {
        return string.Format("{0}/IMG/ IMG_{1}.png", Application.dataPath, System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
    }
}
