using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class Excel : MonoBehaviour

{
    public GameObject player;
    public Rigidbody RB;
    public static float Speed;
    public static float Steer_Angle;
    public static string IMG_filename;
    private List<string[]> rowData = new List<string[]>();

    // Start is called before the first frame update
    void Start()
    {
        //Creating First row of titles manually..

        InvokeRepeating("xel", 1.0f, 0.05f);
    }

    // Update is called once per frame
    void xel()
    {
        Debug.Log("started");
        RB = player.GetComponent<Rigidbody>();
        Speed = RB.velocity.magnitude;

        GameObject CAR = GameObject.Find("CAR");
        CarControl CarControl = CAR.GetComponent<CarControl>();
        Steer_Angle = CarControl.currentSteerAngle;


        IMG_filename = SR_RenderCamera.FN;

        string[] rowDataTemp = new string[3];
        rowDataTemp[0] = Speed.ToString();
        rowDataTemp[1] = Steer_Angle.ToString();
        rowDataTemp[2] = IMG_filename.ToString();
        rowData.Add(rowDataTemp);

        // You can add up the values in as many cells as you want.

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        //StreamWriter outStream = System.IO.File.CreateText(filePath);
        //outStream.WriteLine(sb);
        //outStream.Close();

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, sb.ToString());
        else
            File.AppendAllText(filePath, sb.ToString());

    }
   
    private string getPath()
    {
       
        return string.Format("{0}/CSV/ data.csv", Application.dataPath);
    }
}
