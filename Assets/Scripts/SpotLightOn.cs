using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightOn : MonoBehaviour
{
    public GameObject Flashlight;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void LightOn()
    {
        Flashlight.SetActive(true);
    }

    public void LightOff()
    {
        Flashlight.SetActive(false);
    }
}
