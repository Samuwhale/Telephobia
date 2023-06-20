using System.Runtime.InteropServices;
using UnityEngine;

public static class CursorControl
{
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetCursorPos(out POINT lpPoint);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetCursorPos(int x, int y);

    [StructLayout(LayoutKind.Sequential)]
    private struct POINT { public int x, y; }

    /// <summary>
    /// Sets the cursor to a specific position relative to the upper-left corner of the main monitor screen
    /// </summary>
    /// <param name="position">Position to set, in pixels</param>
    public static void SetPosition(Vector2 position)
    {
        SetPosition((int)position.x, (int)position.y);
    }

    /// <summary>
    /// Sets the cursor to a specific position relative to the upper-left corner of the main monitor screen
    /// </summary>
    /// <param name="x">The X coordinate, in pixels</param>
    /// <param name="y">The Y coordinate, in pixels</param>
    public static void SetPosition(float x, float y)
    {
        SetPosition((int)x, (int)y);
    }

    /// <summary>
    /// Sets the cursor to a specific position relative to the upper-left corner of the main monitor screen
    /// </summary>
    /// <param name="x">The X coordinate, in pixels</param>
    /// <param name="y">The Y coordinate, in pixels</param>
    public static void SetPosition(int x, int y)
    {
        if (!SetCursorPos(x, y))
            Debug.LogError("Unknown Exception. Failed to move cursor.");
    }

    /// <summary>
    /// Returns the cursor position relative to the upper-left corner of the main monitor screen, in pixels
    /// </summary>
    /// <returns></returns>
    public static Vector2 GetPosition()
    {
        var point = new POINT();
        if (!GetCursorPos(out point))
        {
            Debug.LogError("Unknown Exception. Failed to get cursor position, Vector2.Zero returned");
            return Vector2.zero;
        }
        return new Vector2(point.x, point.y);
    }
}
