using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Controllib.utils
{
    public enum Styles : uint
    {
        WsOverlapped = 0x00000000,
        WsPopup = 0x80000000,
        WsChild = 0x40000000,
        WsMinimize = 0x20000000,
        WsVisible = 0x10000000,
        WsDisabled = 0x08000000,
        WsClipsiblings = 0x04000000,
        WsClipchildren = 0x02000000,
        WsMaximize = 0x01000000,
        WsCaption = 0x00C00000,
        WsBorder = 0x00800000,
        WsDlgframe = 0x00400000,
        WsVscroll = 0x00200000,
        WsHscroll = 0x00100000,
        WsSysmenu = 0x00080000,
        WsThickframe = 0x00040000,
        WsGroup = 0x00020000,
        WsTabstop = 0x00010000,
        GwlStyle = 0xFFFFFFF0,
    }

    public enum Msgs
    {
        // GetWindow
        GwHwndfirst = 0,
        GwHwndlast = 1,
        GwHwndnext = 2,
        GwHwndprev = 3,
        GwOwner = 4,
        GwChild = 5,

        // Window messages - WinUser.h
        WmNull = 0x0000,
        WmCreate = 0x0001,
        WmDestroy = 0x0002,
        WmMove = 0x0003,
        WmSize = 0x0005,
        WmKillfocus = 0x0008,
        WmSetredraw = 0x000B,
        WmGettext = 0x000D,
        WmGettextlength = 0x000E,
        WmPaint = 0x000F,
        WmErasebkgnd = 0x0014,
        WmShowwindow = 0x0018,

        WmFontchange = 0x001d,
        WmSetcursor = 0x0020,
        WmMouseactivate = 0x0021,
        WmChildactivate = 0x0022,

        WmDrawitem = 0x002B,
        WmMeasureitem = 0x002C,
        WmDeleteitem = 0x002D,
        WmVkeytoitem = 0x002E,
        WmChartoitem = 0x002F,

        WmSetfont = 0x0030,
        WmCompareitem = 0x0039,
        WmWindowposchanging = 0x0046,
        WmWindowposchanged = 0x0047,
        WmNotify = 0x004E,
        WmNotifyformat = 0x0055,
        WmStylechanging = 0x007C,
        WmStylechanged = 0x007D,
        WmNcmousemove = 0x00A0,
        WmNclbuttondown = 0x00A1,

        WmNccreate = 0x0081,
        WmNcdestroy = 0x0082,
        WmNccalcsize = 0x0083,
        WmNchittest = 0x0084,
        WmNcpaint = 0x0085,
        WmGetdlgcode = 0x0087,

        // from WinUser.h and RichEdit.h
        EmGetsel = 0x00B0,
        EmSetsel = 0x00B1,
        EmGetrect = 0x00B2,
        EmSetrect = 0x00B3,
        EmSetrectnp = 0x00B4,
        EmScroll = 0x00B5,
        EmLinescroll = 0x00B6,
        //EM_SCROLLCARET       = 0x00B7,
        EmGetmodify = 0x00B8,
        EmSetmodify = 0x00B9,
        EmGetlinecount = 0x00BA,
        EmLineindex = 0x00BB,
        EmSethandle = 0x00BC,
        EmGethandle = 0x00BD,
        EmGetthumb = 0x00BE,
        EmLinelength = 0x00C1,
        EmLinefromchar = 0x00C9,
        EmGetfirstvisibleline = 0x00CE,
        EmSetmargins = 0x00D3,
        EmGetmargins = 0x00D4,
        EmPosfromchar = 0x00D6,
        EmCharfrompos = 0x00D7,

        WmKeyfirst = 0x0100,
        WmKeydown = 0x0100,
        WmKeyup = 0x0101,
        WmChar = 0x0102,
        WmDeadchar = 0x0103,
        WmSyskeydown = 0x0104,
        WmSyskeyup = 0x0105,
        WmSyschar = 0x0106,
        WmSysdeadchar = 0x0107,

        WmCommand = 0x0111,
        WmSyscommand = 0x0112,
        WmTimer = 0x0113,
        WmHscroll = 0x0114,
        WmVscroll = 0x0115,
        WmUpdateuistate = 0x0128,
        WmQueryuistate = 0x0129,
        WmMousefirst = 0x0200,
        WmMousemove = 0x0200,
        WmLbuttondown = 0x0201,
        WmLbuttonup = 0x0202,
        WmParentnotify = 0x0210,

        WmNextmenu = 0x0213,
        WmSizing = 0x0214,
        WmCapturechanged = 0x0215,
        WmMoving = 0x0216,

        WmImeSetcontext = 0x0281,
        WmImeNotify = 0x0282,
        WmImeControl = 0x0283,
        WmImeCompositionfull = 0x0284,
        WmImeSelect = 0x0285,
        WmImeChar = 0x0286,
        WmImeRequest = 0x0288,
        WmImeKeydown = 0x0290,
        WmImeKeyup = 0x0291,
        WmNcmousehover = 0x02A0,
        WmNcmouseleave = 0x02A2,
        WmMousehover = 0x02A1,
        WmMouseleave = 0x02A3,

        WmCut = 0x0300,
        WmCopy = 0x0301,
        WmPaste = 0x0302,
        WmClear = 0x0303,
        WmUndo = 0x0304,
        WmRenderformat = 0x0305,
        WmRenderallformats = 0x0306,
        WmDestroyclipboard = 0x0307,
        WmDrawclipboard = 0x0308,
        WmPaintclipboard = 0x0309,
        WmVscrollclipboard = 0x030A,
        WmSizeclipboard = 0x030B,
        WmAskcbformatname = 0x030C,
        WmChangecbchain = 0x030D,
        WmHscrollclipboard = 0x030E,
        WmQuerynewpalette = 0x030F,
        WmPaletteischanging = 0x0310,
        WmPalettechanged = 0x0311,
        WmHotkey = 0x0312,

        WmUser = 0x0400,
        EmScrollcaret = (WmUser + 49),

        EmCanpaste = (WmUser + 50),
        EmDisplayband = (WmUser + 51),
        EmExgetsel = (WmUser + 52),
        EmExlimittext = (WmUser + 53),
        EmExlinefromchar = (WmUser + 54),
        EmExsetsel = (WmUser + 55),
        EmFindtext = (WmUser + 56),
        EmFormatrange = (WmUser + 57),
        EmGetcharformat = (WmUser + 58),
        EmGeteventmask = (WmUser + 59),
        EmGetoleinterface = (WmUser + 60),
        EmGetparaformat = (WmUser + 61),
        EmGetseltext = (WmUser + 62),
        EmHideselection = (WmUser + 63),
        EmPastespecial = (WmUser + 64),
        EmRequestresize = (WmUser + 65),
        EmSelectiontype = (WmUser + 66),
        EmSetbkgndcolor = (WmUser + 67),
        EmSetcharformat = (WmUser + 68),
        EmSeteventmask = (WmUser + 69),
        EmSetolecallback = (WmUser + 70),
        EmSetparaformat = (WmUser + 71),
        EmSettargetdevice = (WmUser + 72),
        EmStreamin = (WmUser + 73),
        EmStreamout = (WmUser + 74),
        EmGettextrange = (WmUser + 75),
        EmFindwordbreak = (WmUser + 76),
        EmSetoptions = (WmUser + 77),
        EmGetoptions = (WmUser + 78),
        EmFindtextex = (WmUser + 79),

        // Tab Control Messages - CommCtrl.h
        TcmDeleteitem = 0x1308,
        TcmInsertitem = 0x133E,
        TcmGetitemrect = 0x130A,
        TcmGetcursel = 0x130B,
        TcmSetcursel = 0x130C,
        TcmAdjustrect = 0x1328,
        TcmSetitemsize = 0x1329,
        TcmSetpadding = 0x132B,

        // olectl.h
        OcmBase = (WmUser + 0x1c00),
        OcmCommand = (OcmBase + WmCommand),
        OcmDrawitem = (OcmBase + WmDrawitem),
        OcmMeasureitem = (OcmBase + WmMeasureitem),
        OcmDeleteitem = (OcmBase + WmDeleteitem),
        OcmVkeytoitem = (OcmBase + WmVkeytoitem),
        OcmChartoitem = (OcmBase + WmChartoitem),
        OcmCompareitem = (OcmBase + WmCompareitem),
        OcmHscroll = (OcmBase + WmHscroll),
        OcmVscroll = (OcmBase + WmVscroll),
        OcmParentnotify = (OcmBase + WmParentnotify),
        OcmNotify = (OcmBase + WmNotify),

    }

    [Flags]
    public enum Flags
    {
        // SetWindowPos Flags - WinUser.h
        SwpNosize = 0x0001,
        SwpNomove = 0x0002,
        SwpNozorder = 0x0004,
        SwpNoredraw = 0x0008,
        SwpNoactivate = 0x0010,
        SwpFramechanged = 0x0020,
        SwpShowwindow = 0x0040,
        SwpHidewindow = 0x0080,
        SwpNocopybits = 0x0100,
        SwpNoownerzorder = 0x0200,
        SwpNosendchanging = 0x0400,
    };
    

    [StructLayout(LayoutKind.Sequential)]
    public struct Windowpos
    {
        public IntPtr hwnd, hwndInsertAfter;
        public int x, y, cx, cy, flags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct Stylestruct
    {
        public int styleOld;
        public int styleNew;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct Createstruct
    {
        public IntPtr lpCreateParams;
        public IntPtr hInstance;
        public IntPtr hMenu;
        public IntPtr hwndParent;
        public int cy;
        public int cx;
        public int y;
        public int x;
        public int style;
        public string lpszName;
        public string lpszClass;
        public int dwExStyle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Charformat
    {
        public int cbSize;
        public UInt32 dwMask;
        public UInt32 dwEffects;
        public Int32 yHeight;
        public Int32 yOffset;
        public Int32 crTextColor;
        public byte bCharSet;
        public byte bPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szFaceName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Pointl
    {
        public Int32 X;
        public Int32 Y;
    }

    public static class User32
    {
        public const int ScfSelection = 0x0001;

        /* Edit control EM_SETMARGIN parameters */
        public const int EcLeftmargin = 0x0001;
        public const int EcRightmargin = 0x0002;

        private static Type _tmsgs = typeof(Msgs);

        public static string Mnemonic(int z)
        {
            foreach (int ix in Enum.GetValues(_tmsgs))
            {
                if (z == ix)
                    return Enum.GetName(_tmsgs, ix);
            }

            return z.ToString("X4");
        }

        public static void BeginUpdate(IntPtr hWnd)
        {
            SendMessage(hWnd, (int)Msgs.WmSetredraw, 0, IntPtr.Zero);
        }

        public static void EndUpdate(IntPtr hWnd)
        {
            SendMessage(hWnd, (int)Msgs.WmSetredraw, 1, IntPtr.Zero);
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd,
                                                [MarshalAs(UnmanagedType.I4)] Msgs msg,
                                                int wParam,
                                                IntPtr lParam);


        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd,
                                                [MarshalAs(UnmanagedType.I4)] Msgs msg,
                                                int wParam,
                                                int lParam);


        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wparam, IntPtr lparam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wparam, int lparam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern int SendMessageRef(IntPtr hWnd, int msg, out int wparam, out int lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, char[] className, int maxCount);

        [DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
                                              int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowLong(IntPtr hWnd, uint nIndex);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, uint nIndex, uint dwNewLong);

        

        public static void Invalidate(IntPtr handle)
        {
            SendMessage(handle, Msgs.WmPaint, 0, 0);
        }
    }
}
