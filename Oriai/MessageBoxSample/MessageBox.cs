using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoxSample
{
    /*
     int MessageBox(
  [in, optional] HWND    hWnd,
  [in, optional] LPCTSTR lpText,
  [in, optional] LPCTSTR lpCaption,
  [in]           UINT    uType
);
     */
    internal class MessageBoxWrapper
    {
        [DllImport("User32.dll")]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        public static void ShowMessageBox(string content, string title, MessageBoxType type, MessageBoxIcon icon)
        {
            if (Environment.OSVersion.Platform != PlatformID.Unix)
                MessageBox(IntPtr.Zero, content, title, (uint)type | (uint)icon);
        }
    }

    public enum MessageBoxType : uint
    {
        AbortRetryIgnore = 0x00000002,
        CancelTryContinue = 0x00000006,
        Help = 0x00004000,
        Ok = 0x00000000,
        OkCancel = 0x00000001,
        RetryCancel = 0x00000005,
        YesNo = 0x00000004,
        YesNoCancel = 0x00000003,
    }

    public enum MessageBoxIcon : uint
    {
        Exclamation = 0x00000030,
        Information = 0x00000040,
    }
}
/*
Value 	Meaning

MB_ICONEXCLAMATION
0x00000030L

	An exclamation-point icon appears in the message box.

MB_ICONWARNING
0x00000030L

	An exclamation-point icon appears in the message box.

MB_ICONINFORMATION
0x00000040L

	An icon consisting of a lowercase letter i in a circle appears in the message box.

MB_ICONASTERISK
0x00000040L

	An icon consisting of a lowercase letter i in a circle appears in the message box.

MB_ICONQUESTION
0x00000020L

	A question-mark icon appears in the message box. The question-mark message icon is no longer recommended because it does not clearly represent a specific type of message and because the phrasing of a message as a question could apply to any message type. In addition, users can confuse the message symbol question mark with Help information. Therefore, do not use this question mark message symbol in your message boxes. The system continues to support its inclusion only for backward compatibility.

MB_ICONSTOP
0x00000010L

	A stop-sign icon appears in the message box.

MB_ICONERROR
0x00000010L

	A stop-sign icon appears in the message box.

MB_ICONHAND
0x00000010L

	A stop-sign icon appears in the message box. 
 */
