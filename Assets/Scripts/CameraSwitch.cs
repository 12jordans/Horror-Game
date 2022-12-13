using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    // Call this function to disable FPS camera,
    // and enable overhead camera.
    public void GhostCam()
    {
        cam1.enabled = false;
        cam2.enabled = true;
    }

    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void MainCam()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }
}
