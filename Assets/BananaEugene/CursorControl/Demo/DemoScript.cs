using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoScript : MonoBehaviour
{
    public Text positionText;

    public void CenterCursor()
    {
        CursorControl.SetPosition(1920 / 2f, 1080 / 2f);
    }

    private void Update()
    {
        Vector2 cursorPos = CursorControl.GetPosition();
        positionText.text = cursorPos.ToString();
    }
}
