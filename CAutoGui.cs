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

// d8888b. db    db       d8888b. d8888b. d88888b .d8888.  .d88b.  d8888b. d88888b db    db
// 88  `8D `8b  d8'       88  `8D 88  `8D 88'     88'  YP .8P  Y8. 88  `8D 88'     88    88
// 88oooY'  `8bd8'        88oooY' 88oobY' 88ooooo `8bo.   88    88 88   88 88ooooo Y8    8P
// 88~~~b.    88          88~~~b. 88`8b   88~~~~~   `Y8b. 88    88 88   88 88~~~~~ `8b  d8'
// 88   8D    88          88   8D 88 `88. 88.     db   8D `8b  d8' 88  .8D 88.      `8bd8'
// Y8888P'    YP          Y8888P' 88   YD Y88888P `8888Y'  `Y88P'  Y8888D' Y88888P    YP

using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;

public class cyautogui
{
    class def
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static int Wait_Time_Global = 1000;
    }

    public static void Wait_Time(int time)
    {
        def.Wait_Time_Global = time;
    }

    public class Mouse
    {
        public static void DoMouseRightClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x08 | 0x10, X, Y, 0, 0);
        }

        public static void MoveAndRightClick(int x, int y)
        {
            while (Cursor.Position.X != x) { Cursor.Position = new Point(x, y); }
            while (Cursor.Position.Y != y) { Cursor.Position = new Point(x, y); }
            def.mouse_event(0x08 | 0x10, (uint)x, (uint)y, 0, 0);
        }

        public static void MoveCursorRelAndRightClick(int x, int y)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            while (Cursor.Position.X != X) { Cursor.Position = new Point((int)X, (int)Y); }
            while (Cursor.Position.Y != Y) { Cursor.Position = new Point((int)X, (int)Y); }
            def.mouse_event(0x08 | 0x10, X, Y, 0, 0);
        }

        public static void DoMouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
        }

        public static void MoveAndClick(int x, int y)
        {
            while (Cursor.Position.X != x) { Cursor.Position = new Point(x, y); }
            while (Cursor.Position.Y != y) { Cursor.Position = new Point(x, y); }
            def.mouse_event(0x02 | 0x04, (uint)x, (uint)y, 0, 0);
        }


        public static void MoveCursorRelAndClick(int x, int y)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            while (Cursor.Position.X != X) { Cursor.Position = new Point((int)X, (int)Y); }
            while (Cursor.Position.Y != Y) { Cursor.Position = new Point((int)X, (int)Y); }
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
        }


        public static void DoMouseDoubleClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
        }

        public static void MoveAndDoubleClick(int x, int y)
        {
            while (Cursor.Position.X != x) { Cursor.Position = new Point(x, y); }
            while (Cursor.Position.Y != y) { Cursor.Position = new Point(x, y); }
            def.mouse_event(0x02 | 0x04, (uint)x, (uint)y, 0, 0);
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            def.mouse_event(0x02 | 0x04, (uint)x, (uint)y, 0, 0);
        }

        public static void MoveCursorRelAndDoubleClick(int x, int y)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            while (Cursor.Position.X != X) { Cursor.Position = new Point((int)X, (int)Y); }
            while (Cursor.Position.Y != Y) { Cursor.Position = new Point((int)X, (int)Y); }
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            def.mouse_event(0x02 | 0x04, X, Y, 0, 0);
        }

        public static void MoveCursorTo(int x, int y)
        {
            while (Cursor.Position.X != x) { Cursor.Position = new Point(x, y); }
            while (Cursor.Position.Y != y) { Cursor.Position = new Point(x, y); }
        }

        public static void MoveCursorRel(int x, int y)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            while (Cursor.Position.X != X) { Cursor.Position = new Point((int)X, (int)Y); }
            while (Cursor.Position.Y != Y) { Cursor.Position = new Point((int)X, (int)Y); }
        }




    }

    public class Info
    {
        public class Mouse
        {
            public class return_INT
            {
                public static int Mouse_Pos_Y()
                {
                    return Cursor.Position.Y;
                }
                public static int Mouse_Pos_X()
                {
                    return Cursor.Position.X;
                }
            }

            public class return_STRING
            {
                public static string Mouse_Pos_Y()
                {
                    return Convert.ToString(Cursor.Position.Y);
                }
                public static string Mouse_Pos_X()
                {
                    return Convert.ToString(Cursor.Position.X);
                }
            }

        }

        public class Screens
        {
            public class return_STRING
            {
                public static string Screen_Size_X()
                {
                    return Convert.ToString(Screen.PrimaryScreen.Bounds.Width);
                }
                public static string Screen_Size_Y()
                {
                    return Convert.ToString(Screen.PrimaryScreen.Bounds.Height);
                }
            }

            public class return_INT
            {
                public static int Screen_Size_X()
                {
                    return Screen.PrimaryScreen.Bounds.Width;
                }
                public static int Screen_Size_Y()
                {
                    return Screen.PrimaryScreen.Bounds.Height;
                }
            }
        }




    }

    public class Keyboard
    {
        public static void Shift_(string key)
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("+{" + key.ToLower() + "}");
        }

        public static void Alt_(string key)
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("%{" + key.ToLower() + "}");
        }

        public static void TAB(int times)
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("^{TAB " + times + "}");
        }

        public static void Alt_Tab()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("%{Tab}");
        }
        public static void Press_Enter()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("{ENTER}");
        }

        public static void Press_PageDown()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{PGDN}");
        }
        public static void Press_PageUp()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{PGUP}");
        }


        public static void Press_Backspace()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{BACKSPACE}");
        }

        public static void Press_Capslock()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{CAPSLOCK}");
        }

        public static void Press_Delete()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{DELETE}");
        }

        public static void Press_Arrow_Down()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{DOWN}");
        }
        public static void Press_Arrow_Up()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{UP}");
        }
        public static void Press_Arrow_Left()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{LEFT}");
        }
        public static void Press_Arrow_Right()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{RIGHT}");
        }

        public static void Press_ESC()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{ESC}");
        }

       



        public static void CTRL_(string key)
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("^{" + key.ToLower() + "}");
        }


        public static void Press_End()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{END}");
        }

        public static void Press_Home()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{HOME}");
        }

        public static void Select_This_Line()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{HOME}");
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("+{END}");
        }

        public static void Copy_Selected_Item()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("^{c}");
        }

        public static void Cut_Selected_Item()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("^{x}");
        }

        public static void Paste_Selected_Item()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("^{v}");
        }



        public static void Write(string key)
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send(key);
        }

        public static void Write_More_Than_1_time(string key, int times)
        { 
            for (int i = 0; i != times; i++)
                SendKeys.SendWait(key);

        }

        public static void KeyPress(string key)
        {
            //https://learn.microsoft.com/pt-br/dotnet/api/system.windows.forms.sendkeys.send?view=windowsdesktop-7.0
            SendKeys.Send("{" + key + "}"); 
        }
    }

    public class Misc_Options
    {
        public static void Alert(string msg)
        {
            MessageBox.Show(msg);
        }
        public static void Printsreen()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{PRTSC}");
        }

        public static void Start_Notepad()
        { 
            Process.Start("notepad.exe");
            Process[] pname = Process.GetProcessesByName("notepad");
            while (pname.Length == 0) {
                System.Threading.Thread.Sleep(def.Wait_Time_Global);
            } 
        }

        public static void Start_CMD()
        {
            Process.Start("cmd.exe");
            Process[] pname = Process.GetProcessesByName("cmd");
            while (pname.Length == 0) {
                System.Threading.Thread.Sleep(def.Wait_Time_Global);
            } 
        }

        public static void Start_CMD_and_run_command(string command)
        {
            Process.Start("cmd.exe", "/C " + command);
            Process[] pname = Process.GetProcessesByName("cmd");
            while (pname.Length == 0)
            {
                System.Threading.Thread.Sleep(def.Wait_Time_Global);
            }
        }

        public static int Get_Process_ID_by_Name(string processName)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if(theprocess.ProcessName == processName)
                {
                    return theprocess.Id;
                }
            }
            return 0;
        }

        public static string Get_Process_Name_by_ID(int processID)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.Id == processID)
                {
                    return theprocess.ProcessName;
                }
            }
            return "Process Not Found";
        }

        public static void Kill_Process_by_Name(string name)
        {
            foreach (var process in Process.GetProcessesByName(name))
            {
                process.Kill();
            }
        }

        public static void Kill_Process_by_ID(int id)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.Id == id)
                {
                    theprocess.Kill();
                }
            }
        }


        public static void Start_Process(string ExePath)
        {
            Process.Start(ExePath);
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
        }
    }
}
