using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenshotScript : MonoBehaviour
{
    int ctr = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ctr % 6 == 0)
        {
            try
            {
                ScreenCapture.CaptureScreenshot("E:\\Unity Projects\\UAV_QR_Decode\\Records\\uav.png");
                File.Copy("E:\\Unity Projects\\UAV_QR_Decode\\Records\\uav.png", "E:\\Unity Projects\\UAV_QR_Decode\\Records\\out.png", true);
            }
            catch (System.Exception)
            {
                Debug.Log("Hata");
            }
        }
        ctr++;
    }
}
