/*
   -------------------C Auto Gui Class--------------------------
   ------------------------------------------------------------
                     Created by BresoDEV
 
    Based on the famous tool in Python, PYAUTOGUI
    I present to you, a class in C# with similar functionality
    With this tool, you can control your mouse and keyboard 
    automatically, so you can easily create task automation
    for inumerous things


 
 */

using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
public class cyautogui
{
    class def
    {
        /// <summary>
        /// Global WAIT timer
        /// </summary>
        public static int GLOBAL_TIME = 500;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

    }
    public class Mouse
    {
        /// <summary>
        /// Do a mouse right clik on current mouse position
        /// </summary>
        public static void DoMouseRightClick()
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x08 | 0x10, X, Y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Move cursor to XY pos and do right click
        /// </summary>
        public static void MoveAndRightClick(int x, int y)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            def.mouse_event(0x08 | 0x10, (uint)x, (uint)y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Move cursor relative to current position and do right click
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveCursorRelAndRightClick(int x, int y)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            Cursor.Position = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x08 | 0x10, X, Y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Do a mouse clik on current mouse position
        /// </summary>
        public static void DoMouseClick()
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Move cursor to XY pos and do click
        /// </summary>
        public static void MoveAndClick(uint x, uint y)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            def.mouse_event(0x02 | 0x04, x, y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Move cursor relative to current position and do click
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveCursorRelAndClick(int x, int y)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            Cursor.Position = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Do double click on current position
        /// </summary>
        public static void DoMouseDoubleClick()
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Move cursor to XY position and do double click
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveAndDoubleClick(int x, int y)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            def.mouse_event(0x02 | 0x04, (uint)x, (uint)y, 0, 0);
            def.mouse_event(0x02 | 0x04, (uint)x, (uint)y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Move cursor to XY current relative position and do double click
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveCursorRelAndDoubleClick(int x, int y)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            Cursor.Position = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Move the mouse to XY coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveCursorTo(int x, int y)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            Cursor.Position = new Point(x, y);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Move mouse relative to its current position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveCursorRel(int x, int y)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            Cursor.Position = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Get the Y position of the mouse
        /// </summary>
        /// <returns></returns>
        public static int getMouseY()
        {
            return Cursor.Position.Y;
        }
        /// <summary>
        /// Get the X position of the mouse
        /// </summary>
        /// <returns></returns>
        public static int getMouseX()
        {
            getMouseY();
            return Cursor.Position.X;
        }
        /// <summary>
        /// Get the Y position of the mouse on STRING format
        /// </summary>
        /// <returns></returns>
        public static string StringgetMouseY()
        {
            return Convert.ToString(Cursor.Position.Y);
        }
        /// <summary>
        /// Get the X position of the mouse on STRING format
        /// </summary>
        /// <returns></returns>
        public static string StringgetMouseX()
        {
            getMouseY();
            return Convert.ToString(Cursor.Position.X);
        }
    }
    public class Keyboard
    {
        /// <summary>
        /// Used if you need press hotkeys, like Shift+A, Shift+Z<br /><br />
        /// Example of Shift+A:<br />
        /// ShiftHotkey("a");<br /><br />
        /// TIP: Allways LOWER case 
        /// </summary>
        /// <param name="key"></param>
        public static void ShiftHotkey(string key)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            SendKeys.Send("+{" + key + "}");
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Used if you need press hotkeys, like Alt+A, Alt+Z<br /><br />
        /// Example of Alt+A:<br />
        /// AltHotkey("a");<br /><br />
        /// TIP: Allways LOWER case 
        /// </summary>
        /// <param name="key"></param>
        public static void AltHotkey(string key)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            SendKeys.Send("%{" + key + "}");
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Simulates you cliqued TAB to change to next imput ou next object
        /// </summary>
        /// <param name="key"></param>
        public static void TAB(int times)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            SendKeys.Send("^{TAB " + times + "}");
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Used if you need press hotkeys, like Ctrl+A, Ctrl+Z<br /><br />
        /// Example of Ctrl+A:<br />
        /// CTRLHotkey("a");<br /><br />
        /// TIP: Allways LOWER case 
        /// </summary>
        /// <param name="key"></param>
        public static void CTRLHotkey(string key)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            SendKeys.Send("^(" + key + ")");
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Write string, simulates keyboard
        /// </summary>
        /// <param name="key"></param>
        public static void Write(string key)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            SendKeys.Send(key);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Used to press same key, what times you want <br /> <br />
        /// Ex: <br />
        /// WriteMoreThan1time("A", 10);<br />
        /// That code, press key A, 10x<br />
        /// Output: AAAAAAAAAA
        /// </summary>
        /// <param name="key"></param>
        /// <param name="times"></param>
        public static void WriteMoreThan1time(string key, int times)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            SendKeys.SendWait("{" + key + " " + Convert.ToString(times) + "}");
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary><br />
        /// <br /><br />Simulate keyboard press<br /><br />
        /// Read more on Google, search for <br />
        /// SENDKEYS C# <br />
        /// to see all combinations
        /// </summary>
        /// <param name="key"></param>
        public static void KeyPress(string key)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            SendKeys.Send("{" + key + "}");
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
    }
    public class Other
    {
        /// <summary>
        /// Define your new Global Wait Timer, default is 500
        /// </summary>
        /// <param name="time"></param>
        public static void ChangeGlobalTimePointer(int time)
        {
            def.GLOBAL_TIME = time;
        }
        /// <summary>
        /// Start another process by name
        /// </summary>
        /// <param name="proc"></param>
        public static void StartProcess(string proc)
        {
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
            Process p = Process.Start(proc);
            System.Threading.Thread.Sleep(def.GLOBAL_TIME);
        }
        /// <summary>
        /// Used to open folders or files on your PC
        /// </summary>
        /// <param name="path"></param>
        public static void OpenFolder(string path)
        { 
            Process.Start(@path);
        }
        /// <summary>
        /// Get the size X of the primary monitor on string format
        /// </summary>
        /// <returns></returns>
        public static string StringsizeScreenX()
        {
            return Convert.ToString(Screen.PrimaryScreen.Bounds.Width);
        }
        /// <summary>
        /// Get the size Y of the primary monitor on string format
        /// </summary>
        /// <returns></returns>
        public static string StringsizeScreenY()
        {
            return Convert.ToString(Screen.PrimaryScreen.Bounds.Height);
        }
        /// <summary>
        /// Get the size X of the primary monitor
        /// </summary>
        /// <returns></returns>
        public static int sizeScreenX()
        {
            return Screen.PrimaryScreen.Bounds.Width;
        }
        /// <summary>
        /// Get the size Y of the primary monitor
        /// </summary>
        /// <returns></returns>
        public static int sizeScreenY()
        {
            return Screen.PrimaryScreen.Bounds.Height;
        }
        /// <summary>
        /// This displays some text with an OK button.
        /// </summary>
        /// <param name="msg"></param>
        public static void alert(string msg)
        {
            MessageBox.Show(msg);
        }
        /// <summary>
        /// Do some pause on code. <br /><br />
        /// Ex: <br />
        /// 1 second = 1000<br />
        /// 2 seconds = 2000<br /><br />
        /// Values is ever * 1000
        /// </summary>
        /// <param name="timeMiliseconds"></param>
        public static void Wait(int timeMiliseconds)
        {

            System.Threading.Thread.Sleep(def.GLOBAL_TIME);

        }

        /// <summary>
        /// Join several string and make onlt one
        /// </summary>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        /// <param name="_8"></param>
        /// <param name="_9"></param>
        /// <param name="_10"></param>
        /// <param name="_11"></param>
        /// <param name="_12"></param>
        /// <param name="_13"></param>
        /// <param name="_14"></param>
        /// <param name="_15"></param>
        /// <param name="_16"></param>
        /// <param name="_17"></param>
        /// <param name="_18"></param>
        /// <param name="_19"></param>
        /// <param name="_20"></param>
        /// <param name="_21"></param>
        /// <param name="_22"></param>
        /// <param name="_23"></param>
        /// <param name="_24"></param>
        /// <param name="_25"></param>
        /// <param name="_26"></param>
        /// <param name="_27"></param>
        /// <param name="_28"></param>
        /// <param name="_29"></param>
        /// <param name="_30"></param>
        /// <param name="_31"></param>
        /// <param name="_32"></param>
        /// <param name="_33"></param>
        /// <param name="_34"></param>
        /// <param name="_35"></param>
        /// <param name="_36"></param>
        /// <param name="_37"></param>
        /// <param name="_38"></param>
        /// <param name="_39"></param>
        /// <param name="_40"></param>
        /// <param name="_41"></param>
        /// <param name="_42"></param>
        /// <param name="_43"></param>
        /// <param name="_44"></param>
        /// <param name="_45"></param>
        /// <param name="_46"></param>
        /// <param name="_47"></param>
        /// <param name="_48"></param>
        /// <param name="_49"></param>
        /// <param name="_50"></param>
        /// <returns></returns>
        public static string AddString(string _1 = "", string _2 = "", string _3 = "", string _4 = "", string _5 = "", string _6 = "", string _7 = "", string _8 = "", string _9 = "", string _10 = "", string _11 = "", string _12 = "", string _13 = "", string _14 = "", string _15 = "", string _16 = "", string _17 = "", string _18 = "", string _19 = "", string _20 = "", string _21 = "", string _22 = "", string _23 = "", string _24 = "", string _25 = "", string _26 = "", string _27 = "", string _28 = "", string _29 = "", string _30 = "", string _31 = "", string _32 = "", string _33 = "", string _34 = "", string _35 = "", string _36 = "", string _37 = "", string _38 = "", string _39 = "", string _40 = "", string _41 = "", string _42 = "", string _43 = "", string _44 = "", string _45 = "", string _46 = "", string _47 = "", string _48 = "", string _49 = "", string _50 = "")
        {
            return _1 + _2 + _3 + _4 + _5 + _6 + _7 + _8 + _9 + _10 + _11 + _12 + _13 + _14 + _15 + _16 + _17 + _18 + _19 + _20 + _21 + _22 + _23 + _24 + _25 + _26 + _27 + _28 + _29 + _30 + _31 + _32 + _33 + _34 + _35 + _36 + _37 + _38 + _39 + _40 + _41 + _42 + _43 + _44 + _45 + _46 + _47 + _48 + _49 + _50;
        }
    }
    public class ConvertTo
    {
        /// <summary>
        /// Convert INT value to DOUBLE
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double toDouble(int value)
        {
            return Convert.ToDouble(value);
        }
        /// <summary>
        /// Convert STRING value to DOUBLE
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double toDouble(string value)
        {
            return Convert.ToDouble(value);
        }
        /// <summary>
        /// Convert STRING to INT32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int toInt(string value)
        {
            return Convert.ToInt32(value);
        }
        /// <summary>
        /// Convert FLOAT to INT32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int toInt(float value)
        {
            return Convert.ToInt32(value);
        }
        /// <summary>
        /// Convert INT value to STRING
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string toString(int key) { return Convert.ToString(key); }
        /// <summary>
        /// Convert FLOAT value to STRING
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string toString(float key) { return Convert.ToString(key); }
        /// <summary>
        /// Convert DOUBLE value to STRING
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string toString(double key) { return Convert.ToString(key); }
    }
}
