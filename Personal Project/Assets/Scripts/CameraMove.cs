using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    private Vector3 offsetPosition = new Vector3(0, 4, -10);
    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;
    // Start is called before the first frame update
    private void Update()
    {
        Refresh();
    }

    // Update is called once per frame
    public void Refresh()
    {
        if(target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if(offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if(lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
