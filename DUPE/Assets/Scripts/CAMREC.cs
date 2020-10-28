 using UnityEngine;
 using System.Collections;
[RequireComponent(typeof(Camera))]
public class CAMREC : MonoBehaviour {

    Camera cam;
    public int resWidth = 2550;
    public int resHeight = 3300;

    void Awake()
    {
        cam = GetComponent<Camera>();
        Debug.Log("IMG needs to be taken");
        Debug.Log(cam);
    }


    void LateUpdate()
    {
        Texture2D camtex = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        cam.Render();
        Debug.Log("Update");
        RenderTexture.active = cam.targetTexture;
        camtex.ReadPixels(new Rect(0, 0,resWidth, resHeight), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(cam.targetTexture);
        byte[] bytes = camtex.EncodeToJPG();
        string fileName = jpgName();
        System.IO.File.WriteAllBytes(fileName, bytes);
        Debug.Log("IMG taken");
    }

    string jpgName()
    {
        return string.Format("{0}/IMG/img_{1}", Application.dataPath, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
    