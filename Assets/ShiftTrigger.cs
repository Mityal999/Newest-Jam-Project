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

            Destroy(shiftCanvasObj, 2f);
            Destroy(gameObject, 2f);
        }
    }
}
