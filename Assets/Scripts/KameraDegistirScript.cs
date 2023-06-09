using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraDegistirScript : MonoBehaviour
{
    [SerializeField]
    Camera Cam1, Cam2;
    // Start is called before the first frame update
    void Start()
    {
        Cam1.enabled = true;
        Cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Cam1.enabled)
            {
                Cam2.enabled = true;
                Cam1.enabled = false;
            }
            else
            {
                Cam2.enabled = false;
                Cam1.enabled = true;
            }
        }
    }
}
