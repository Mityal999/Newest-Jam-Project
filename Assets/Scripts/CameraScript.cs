using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera cam;
    private GameObject currentRaycastTarget;

    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }



    private void Update()
    {
        RaycastHit ray;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out ray))
        {
            currentRaycastTarget = ray.transform.gameObject;

            ClickableTypo clickableObject = currentRaycastTarget.GetComponent<ClickableTypo>();
            if (clickableObject != null)
            {
                // Попали лучом в объект с ClickableObject скриптом
                clickableObject.OnRayHit();
            }
        }

    }



}
