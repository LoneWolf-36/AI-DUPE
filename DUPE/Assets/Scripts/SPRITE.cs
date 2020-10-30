using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPRITE : MonoBehaviour
{
    Camera cam;
    public int resWidth = 256;
    public int resHeight = 256;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame

    void OnPostRender()
    {

        Texture2D ScreenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        RenderTexture.active = cam.targetTexture;
        ScreenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        ScreenShot.Apply();
        byte[] PngData = ScreenShot.EncodeToPNG();
        string FileName = IMG_NAME();
        System.IO.File.WriteAllBytes(FileName, PngData);
        Debug.Log("IMG Taken");

    }

    string IMG_NAME()
    {
        return string.Format("{0}/IMG/ IMG_{1}.png", Application.dataPath, System.DateTime.Now.ToString("yyyy-MM-dd"));
    }
}
