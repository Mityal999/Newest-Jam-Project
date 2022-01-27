using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftTrigger : MonoBehaviour
{
    public GameObject shiftCanvasObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shiftCanvasObj.SetActive(true);

            Destroy(shiftCanvasObj, 1.5f);
            Destroy(gameObject, 1.5f);
        }
    }
}
