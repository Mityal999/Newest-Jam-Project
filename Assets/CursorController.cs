using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisableCursor();
    }

    public void EnableCursor()
    {
        Cursor.visible = true;
    }

    public void DisableCursor()
    {
        Cursor.visible = false;
    }
}
