using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGhost : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Vector3 offsetPosition2;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition) + offsetPosition2;
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            Vector3 cameraPosition = target.transform.position;
            cameraPosition.y = transform.position.y;
            transform.LookAt(cameraPosition);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
