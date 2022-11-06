using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    
    private Vector3 rotation = new Vector3(0.0f, 1.0f, 0.0f);
    private float speed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
