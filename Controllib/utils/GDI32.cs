using System;
using System.Runtime.InteropServices;

namespace Controllib.utils
{
    public enum GdiBkMode : int
    {
        Transparent = 1,
        Opaque = 2
    }

    public static class Gdi32
    {
        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, GdiBkMode iBkMode);
    }
}
