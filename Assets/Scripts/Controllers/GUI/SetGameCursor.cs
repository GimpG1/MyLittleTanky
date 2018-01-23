using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameCursor : MonoBehaviour {

    public Texture2D _tankDative;
    public Texture2D _guiDative;

    void Start ()
    {
        Cursor.visible = true;
	}

    public void SetGuiCursor()
    {
        Cursor.SetCursor(_guiDative, Vector2.zero, CursorMode.Auto);
    }

    public void SetInGameCursor()
    {
        Cursor.SetCursor(_tankDative, Vector2.zero, CursorMode.Auto);
    }
}
