using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAKE : MonoBehaviour
{
    Camera cam;
    public int resWidth = 2550;
    public int resHeight = 3300;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        cam.gameObject.SetActive(true);
        Debug.Log("IMG needs to be faken");
    }
}
