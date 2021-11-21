using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlazAura : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EyeKillable")
        {
            Destroy(other.gameObject);
        }
    }

}
