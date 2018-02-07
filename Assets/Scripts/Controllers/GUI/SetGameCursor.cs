using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameCursor : MonoBehaviour {

    public Texture2D _tankDative;
    public Texture2D _guiDative;

   public void ShowCursor (bool value)
    {
        Cursor.visible = value;
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
