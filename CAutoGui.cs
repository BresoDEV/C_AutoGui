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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Xml;
using System.Net.Sockets;
using System.Net.NetworkInformation;

public class cyautogui
{


    private class def
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static int Wait_Time_Global = 1000;

        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WriteProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);


        // privileges
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;

        // used for memory allocation
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        public static string Diretorio;
        public static string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

    }

    public static void Esperar(int tempo)
    {
        int supimpa = tempo * 60;
        int a = 0;
        while (a < supimpa)
        {
            System.Threading.Thread.Sleep(1);
            a++;
        }
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
        public class Computer
        {
            public static string PC_Name()
            {
                return Environment.MachineName;
            }

            public static string Versao_sistema()
            {
                return Convert.ToString(Environment.OSVersion);
            }

            public static string GetLocalIPAddress()
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }

            public static string Get_MAC()
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String enderecoMAC = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    // retorna endereço MAC do primeiro cartão
                    if (enderecoMAC == String.Empty)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        enderecoMAC = adapter.GetPhysicalAddress().ToString();
                    }
                }
                string abc = enderecoMAC[0].ToString() +
                        enderecoMAC[1].ToString() + ":" +
                        enderecoMAC[2].ToString() +
                        enderecoMAC[3].ToString() + ":" +
                        enderecoMAC[4].ToString() +
                        enderecoMAC[5].ToString() + ":" +
                        enderecoMAC[6].ToString() +
                        enderecoMAC[7].ToString() + ":" +
                        enderecoMAC[8].ToString() +
                        enderecoMAC[9].ToString() + ":" +
                        enderecoMAC[10].ToString() +
                        enderecoMAC[11].ToString();
                return abc;
            }
        }
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

        public class Time
        {
            public static int Hour()
            {
                return DateTime.Now.Hour;
            }

            public static int Minutes()
            {
                return DateTime.Now.Minute;
            }
            public static int Seconds()
            {
                return DateTime.Now.Second;
            }

            public static int Miliseconds()
            {
                return DateTime.Now.Millisecond;
            }

            public static string Complete_ClockTime()
            {
                return Convert.ToString(Hour()) + ":" +
                    Convert.ToString(Minutes()) + ":" +
                    Convert.ToString(Seconds()) + ":" +
                    Convert.ToString(Miliseconds());
            }
        }

        public class Date
        {
            public static int Day()
            {
                return DateTime.Now.Day;
            }

            public static int Month()
            {
                return DateTime.Now.Month;
            }

            public static int Year()
            {
                return DateTime.Now.Year;
            }

            public static int Day_of_Year()
            {
                return DateTime.Now.DayOfYear;
            }

            public static int Days_to_End_Year()
            {
                int v = 365 - DateTime.Now.DayOfYear;
                return v;
            }
            public static string Day_of_Week()
            {
                return Convert.ToString(DateTime.Now.DayOfWeek);
            }

            public static string Complete_Date()
            {
                return Convert.ToString(Day()) + "/" +
                    Convert.ToString(Month()) + "/" +
                    Convert.ToString(Year());
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
            SendKeys.Send("%{" + key.ToLower() + "}");
        }

        public static void TAB(int times)
        {
            int tempo = 0;
            while (tempo != def.Wait_Time_Global)
                tempo++;
            SendKeys.Send("^{TAB " + times + "}");
        }

        public static void Alt_Tab()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.Send("%{Tab}");
        }
        public static void Press_Enter()
        {

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
            int tempo = 0;
            while (tempo != cyautogui.def.Wait_Time_Global)
            {
                tempo++;
                if (tempo == cyautogui.def.Wait_Time_Global)
                {
                    SendKeys.Send("^{" + key.ToLower() + "}");
                }
            }

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

            SendKeys.Send("^{v}");

        }



        public static void Write(string key)
        {

            SendKeys.Send(key);
        }

        public static void Write_More_Than_1_time(string key, int times)
        {
            for (int i = 0; i != times; i++)
                SendKeys.SendWait(key);

        }

        public static void KeyPress(string key)
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
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
        public static void Printscreen()
        {
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
            SendKeys.SendWait("{PRTSC}");
        }

        public static void Start_Notepad()
        {
            Process.Start("notepad.exe");
            Process[] pname = Process.GetProcessesByName("notepad");
            while (pname.Length == 0)
            {
                System.Threading.Thread.Sleep(def.Wait_Time_Global);
            }
        }

        public static void Start_CMD()
        {
            Process.Start("cmd.exe");
            Process[] pname = Process.GetProcessesByName("cmd");
            while (pname.Length == 0)
            {
                System.Threading.Thread.Sleep(def.Wait_Time_Global);
            }
        }



        public static void Start_MSPaint()
        {
            Process.Start("mspaint.exe");
            Process[] pname = Process.GetProcessesByName("mspaint");
            while (pname.Length == 0)
            {

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
                if (theprocess.ProcessName == processName)
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

        public static string AddString(string _1 = "", string _2 = "", string _3 = "", string _4 = "", string _5 = "", string _6 = "", string _7 = "", string _8 = "", string _9 = "", string _10 = "", string _11 = "", string _12 = "", string _13 = "", string _14 = "", string _15 = "", string _16 = "", string _17 = "", string _18 = "", string _19 = "", string _20 = "", string _21 = "", string _22 = "", string _23 = "", string _24 = "", string _25 = "", string _26 = "", string _27 = "", string _28 = "", string _29 = "", string _30 = "", string _31 = "", string _32 = "", string _33 = "", string _34 = "", string _35 = "", string _36 = "", string _37 = "", string _38 = "", string _39 = "", string _40 = "", string _41 = "", string _42 = "", string _43 = "", string _44 = "", string _45 = "", string _46 = "", string _47 = "", string _48 = "", string _49 = "", string _50 = "")
        {
            return _1 + _2 + _3 + _4 + _5 + _6 + _7 + _8 + _9 + _10 + _11 + _12 + _13 + _14 + _15 + _16 + _17 + _18 + _19 + _20 + _21 + _22 + _23 + _24 + _25 + _26 + _27 + _28 + _29 + _30 + _31 + _32 + _33 + _34 + _35 + _36 + _37 + _38 + _39 + _40 + _41 + _42 + _43 + _44 + _45 + _46 + _47 + _48 + _49 + _50;
        }
        public static void Start_Process(string ExePath)
        {
            Process.Start(ExePath);
            System.Threading.Thread.Sleep(def.Wait_Time_Global);
        }
    }

    public class Funcoes_Prontas
    {
        public static void Tirar_Print_e_Salvar()
        {

            cyautogui.Misc_Options.Printscreen();
            cyautogui.Esperar(5);
            cyautogui.Misc_Options.Start_MSPaint();
            cyautogui.Esperar(5);
            cyautogui.Keyboard.Paste_Selected_Item();
            cyautogui.Esperar(5);
            cyautogui.Keyboard.Alt_("F4");
            cyautogui.Esperar(5);
            cyautogui.Keyboard.Press_Enter();
            cyautogui.Esperar(5);
            cyautogui.Keyboard.Write("Automacao de imagem");
            cyautogui.Esperar(5);
            cyautogui.Keyboard.Press_Enter();
            cyautogui.Esperar(5);
            cyautogui.Misc_Options.Alert("Concluido");
        }

        public static string Random_Word(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }

    public class Memory_Editor
    {
        public class Pointers
        {
            public int ID_Processo(string nome)
            {
                Process[] processlist = Process.GetProcesses();
                foreach (Process p in processlist)
                {
                    if (nome == p.ProcessName)
                    {
                        return p.Id;
                    }
                }
                return 0;
            }

            public long GetBaseAddress(String EXE, string processo)
            {
                // var procName = "GTA5";
                //long baseAddress = GetBaseAddress(procName + ".exe", "GTA5");
                //this.Text = "BaseAddress: {0}" + (baseAddress).ToString("X"); 

                IntPtr baseAddress = IntPtr.Zero;
                try
                {
                    foreach (ProcessModule PM in Process.GetProcessById(ID_Processo(processo)).Modules)
                    {
                        if (EXE.ToLower() == PM.ModuleName.ToLower())
                            baseAddress = PM.BaseAddress;
                    }
                    return (long)baseAddress;
                }
                catch (Exception ex)
                {
                    return (long)IntPtr.Zero;
                }
            }

            public static void Mudar_Valor(string Processo, int Endereço, int Valor)
            {
                Process process = Process.GetProcessesByName(Processo)[0];
                IntPtr processHandle = def.OpenProcess(0x1F0FFF, false, process.Id);
                int bytesWritten = 0;
                byte[] buffer = BitConverter.GetBytes(Valor); // '\0' marks the end of string
                def.WriteProcessMemory(processHandle, (IntPtr)Endereço, buffer, buffer.Length, ref bytesWritten);
            }

            public int ReadInt_Ponteiros(string Processo, string EXE, int SomaModulo, int pt1 = -1,
            int pt2 = -1, int pt3 = -1, int pt4 = -1, int pt5 = -1, int pt6 = -1, int pt7 = -1,
            int pt8 = -1, int pt9 = -1, int pt10 = -1)
            {
                //Como usar:
                //this.Text = Convert.ToString(ReadInt_Ponteiros("RDR2SourceKripto", "RDR2SourceKripto.exe",
                //0x000872F4, 0x68, 0x4C, 0x370, 0x114, 0x284, 0x64, 0xFA0));
                int aa = 0;
                Process process = Process.GetProcessesByName(Processo)[0];
                int processHandle = (int)def.OpenProcess(0x1F0FFF, false, process.Id);
                byte[] buffer = new byte[8];
                long baseAddress = GetBaseAddress(EXE, Processo);
                def.ReadProcessMemory(processHandle, (int)baseAddress + SomaModulo, buffer, 4, ref aa);
                int inicio = BitConverter.ToInt32(buffer, 0);
                if (pt1 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt1/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt2 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt2/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt3 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt3/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt4 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt4/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt5 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt5/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt6 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt6/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt7 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt7/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt8 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt8/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt9 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt9/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                if (pt10 != -1)
                    def.ReadProcessMemory(processHandle, inicio + pt10/*ponteiro 1*/, buffer, 4, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);

                def.ReadProcessMemory(processHandle, inicio, buffer, buffer.Length, ref aa);
                inicio = BitConverter.ToInt32(buffer, 0);
                return inicio;

            }

            //Melhor metodo, usar esse
            public void GravarIntPonteiro(string processo, string exe, long somaExe, int valor, int[] ponteiros = null)
            {
                /*
                int[] arraya = new int[] { 0xD04, 0xA0, 0x24, 0xC, 0x0, 0x2C, 0xF84 };
                GravarIntPonteiro("Parasita Dashboard", "Parasita Dashboard.exe", 0x000AA0C8, 14, arraya);
                */
                long Offset = somaExe;
                byte[] Buffer = new byte[8];
                int a = 0;
                Process process = Process.GetProcessesByName(processo)[0];
                int processHandle = (int)def.OpenProcess(0x1F0FFF, false, process.Id);
                long baseAddress = GetBaseAddress(exe, processo);
                def.ReadProcessMemory(processHandle, (int)baseAddress + (int)Offset, Buffer, Buffer.Length, ref a);
                if (ponteiros != null)
                {
                    for (int x = 0; x < (ponteiros.Length - 1); x++)
                    {
                        Offset = BitConverter.ToInt64(Buffer, 0) + ponteiros[x];
                        def.ReadProcessMemory(processHandle, (int)Offset, Buffer, Buffer.Length, ref a);
                    }
                    Offset = BitConverter.ToInt64(Buffer, 0) + ponteiros[ponteiros.Length - 1];

                    byte[] buffer = BitConverter.GetBytes(valor);
                    Mudar_Valor(processo, (int)Offset, valor);

                }
            }



            public int LerEnderecModulo(string Processo, string EXE, int SomaModulo)
            {
                /* Como usar:
                int Pt1 = LerEnderecModulo("Parasita Dashboard", "Parasita Dashboard.exe", 0x00020CE0); 
                int Pt0 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt1, 0x38); 
                int Pt2 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt0, 0x8); 
                int Pt3 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt2, 0x4); 
                int Pt4 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt3, 0x20); 
                int Pt5 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt4, 0x140);
                int Pt6 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt5, 0x70);
                Pt6 += 0x660;//Ultimo ponteiro so add, nao ler ele
                Mudar_Valor("Parasita Dashboard", Pt6, 12);
                */

                int aa = 0;
                Process process = Process.GetProcessesByName(Processo)[0];
                int processHandle = (int)def.OpenProcess(0x1F0FFF, false, process.Id);
                byte[] buffer = new byte[8];
                long baseAddress = GetBaseAddress(EXE, Processo);
                def.ReadProcessMemory(processHandle, (int)baseAddress + SomaModulo, buffer, 4, ref aa);
                int inicio = BitConverter.ToInt32(buffer, 0);

                return inicio;
            }

            public int LerEndereco(string Processo, string EXE, int endereco, int pt)
            {
                /* Como usar:
                int Pt1 = LerEnderecModulo("Parasita Dashboard", "Parasita Dashboard.exe", 0x00020CE0); 
                int Pt0 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt1, 0x38); 
                int Pt2 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt0, 0x8); 
                int Pt3 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt2, 0x4); 
                int Pt4 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt3, 0x20); 
                int Pt5 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt4, 0x140);
                int Pt6 = LerEndereco("Parasita Dashboard", "Parasita Dashboard.exe", Pt5, 0x70);
                Pt6 += 0x660;//Ultimo ponteiro so add, nao ler ele
                Mudar_Valor("Parasita Dashboard", Pt6, 12);
                */
                int aa = 0;
                Process process = Process.GetProcessesByName(Processo)[0];
                int processHandle = (int)def.OpenProcess(0x1F0FFF, false, process.Id);
                byte[] buffer = new byte[5000];
                //int inicio;// = BitConverter.ToInt32(buffer, 0);
                def.ReadProcessMemory(processHandle, endereco + pt, buffer, 4, ref aa);
                int inicio = BitConverter.ToInt32(buffer, 0);
                return inicio;
            }

            public static void Mudar_ValorString(string Processo, int Endereço, string Valor)
            {
                Process process = Process.GetProcessesByName(Processo)[0];
                IntPtr processHandle = def.OpenProcess(0x1F0FFF, false, process.Id);
                int bytesWritten = 0;
                byte[] buffer = new ASCIIEncoding().GetBytes(Valor); // '\0' marks the end of string
                def.WriteProcessMemory(processHandle, (IntPtr)Endereço, buffer, buffer.Length, ref bytesWritten);
            }


            public static void Ler_valor_e_exibir(string Processo, int Endereço)
            {
                Process process = Process.GetProcessesByName(Processo)[0];
                int processHandle = (int)def.OpenProcess(0x1F0FFF, false, process.Id);
                byte[] buffer = new byte[4];
                int bytes = 0;
                def.ReadProcessMemory(processHandle, Endereço, buffer, buffer.Length, ref bytes);
                MessageBox.Show(Convert.ToString(Endereço) + " : " + BitConverter.ToInt32(buffer, 0));


            }


            public static int Ler_valor(string Processo, int Endereço)
            {
                Process process = Process.GetProcessesByName(Processo)[0];
                int processHandle = (int)def.OpenProcess(0x1F0FFF, false, process.Id);
                byte[] buffer = new byte[4];
                int bytes = 0;
                def.ReadProcessMemory(processHandle, Endereço, buffer, buffer.Length, ref bytes);
                return BitConverter.ToInt32(buffer, 0);

            }
















        }

        public class Injecao_DLL
        {

            public static void injetar(string processo = "GTAV", string dllpath = "mod.dll")
            {
                Process targetProcess = Process.GetProcessesByName(processo)[0];
                IntPtr procHandle = def.OpenProcess(0x0002 | 0x0400 | 0x0008 | 0x0020 | 0x0010, false, targetProcess.Id);
                IntPtr loadLibraryAddr = def.GetProcAddress(def.GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                string dllName = dllpath;

                IntPtr allocMemAddress = def.VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), 0x00001000 | 0x00002000, 4);
                UIntPtr bytesWritten;
                def.WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
                def.CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            }
        }
    }


    public class Criptografia
    {

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }

    public class Web_Functions
    {
        public static bool Checkar_Conexao()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                request.KeepAlive = false;
                request.Timeout = 10000;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static void download(string link, string ondesalvar)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(link, ondesalvar);
            }
        }
    }

    public class INI_Reader
    {
        //var MyIni = new INI_Reader("Valores.ini");
        //this.Text = MyIni.Ler("oi", "oi2");
        public INI_Reader(string IniPath = null)
        {
            def.Diretorio = new FileInfo(IniPath ?? def.EXE + ".ini").FullName;
        }
        public string Ler(string Sessao, string Nome)
        {
            var RetVal = new StringBuilder(255);
            def.GetPrivateProfileString(Sessao ?? def.EXE, Nome, "", RetVal, 255, def.Diretorio);
            return RetVal.ToString();
        }
        public void Gravar(string Sessao, string Nome, string Valor)//string Key, string Value, string Section = null)
        {
            def.WritePrivateProfileString(Sessao ?? def.EXE, Nome, Valor, def.Diretorio);
        }

        public bool Sessao_Existe(string Sessao, string Nome = null)
        {
            return Ler(Sessao, Nome).Length > 0;
        }

        public void Deletar_Sessao(string Sessao = null)
        {
            Gravar(Sessao ?? def.EXE, null, null);
        }

        public void Deletar_Nome(string Sessao, string Nome)
        {
            Gravar(Sessao ?? def.EXE, Nome, null);
        }


        public int Ler_Int(string Sessao, string Nome)
        {
            var RetVal = new StringBuilder(255);
            def.GetPrivateProfileString(Sessao ?? def.EXE, Nome, "", RetVal, 255, def.Diretorio);
            return Convert.ToInt32(RetVal.ToString());
        }

        public double Ler_Float(string Sessao, string Nome)
        {
            var RetVal = new StringBuilder(255);
            def.GetPrivateProfileString(Sessao ?? def.EXE, Nome, "", RetVal, 255, def.Diretorio);
            return Convert.ToDouble(RetVal.ToString());
        }
    }

    public class XML_Basic
    {
        /*Modelo de XML
          <?xml version="1.0" encoding="utf-8"?>  
            <Students>  
             <Student1>  
                <Texto1>AAA</Texto1>
            	<Texto2>BBB</Texto2>
            	<Texto3>CCC</Texto3> 
              </Student1> 
             <Student2>  
                <Texto1>AAA_2</Texto1>
            	<Texto2>BBB_2</Texto2>
            	<Texto3>CCC_2</Texto3> 
              </Student2>  
            </Students> 
        */
        public static string Ler(string tag, string key)
        {
            //Exemplo:
            // this.Text = cyautogui.XML_Basic.Ler("Student2", "Texto1");
            using (XmlReader reader = XmlReader.Create(@"https://pastebin.com/raw/PPYRQXfK"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (tag == reader.Name.ToString())
                        {
                            while (reader.Read())
                            {
                                if (key == reader.Name.ToString())
                                {
                                    return reader.ReadString();
                                }
                            }
                            //MessageBox.Show(reader.ReadString(),Convert.ToString(a));//pega o valor
                            // MessageBox.Show(reader.Name.ToString(), Convert.ToString(a));//pega as tags
                        }
                    }

                }
            }
            return null;
        }




        public static List<string> Ler_Todos_Valores(string tag, string ultimaTag)
        {
            //Exemplo: Parametro ULTIMA TAG, vai ser onde a leitura finaliza
            //
            //  List<string> aa = cyautogui.XML_Basic.Ler_Todos_Valores("Student2", "Texto3");
            //  for (int i = 0; i <= (aa.Count() - 1); i++)
            //  {
            //        MessageBox.Show(aa[i]);
            //  }
            List<string> Temp = new List<string>();
            using (XmlReader reader = XmlReader.Create(@"https://pastebin.com/raw/PPYRQXfK"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (tag == reader.Name.ToString())
                        {
                            while (reader.Read())
                            {

                                if (reader.ReadString() != "\n" || reader.ReadString() != "\n\t")
                                {
                                    if (ultimaTag == reader.Name.ToString())
                                    {
                                        Temp.Add(reader.ReadString());
                                        break;
                                    }
                                    else
                                        Temp.Add(reader.ReadString());
                                }
                            }
                        }
                    }

                }
            }
            return Temp;
        }

    }

    public class TXT_Files
    {
        public static string Ler(string path)
        {
            //Exemplo:
            //MessageBox.Show(cyautogui.TXT_Files.Ler("E:/jj.txt"));
            return File.ReadAllText(path);
        }

        public static List<string> Ler_Linha_a_Linha(string textFile)
        {
            //Exemplo: 
            //List<string> aa = cyautogui.TXT_Files.Ler_Linha_a_Linha("E:/jj.txt");
            //for (int i = 0; i <= (aa.Count() - 1); i++)
            //    MessageBox.Show(aa[i]);

            List<string> Temp = new List<string>();
            string[] lines = File.ReadAllLines(textFile);
            foreach (string line in lines)
                Temp.Add(line);
            return Temp;
        }
    }

    public class Run_Dialogs
    {
        public static void SaveFileDialog(string textoAserSalvo, string extensoes = "Text|*.txt", string titulo = "Salvar")
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = extensoes;
            saveFileDialog1.Title = titulo;
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile()))
                {
                    sw.Write(textoAserSalvo);
                }
            }
        }

        public static string Directory_Browser()
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }
            return folderPath;
        }

        public static string OpenFileDialog(string extensoes = "Text (*.txt)|*.txt")
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = extensoes;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return File.ReadAllText(openFileDialog1.FileName);
            }
            else
                return "";

        }

        public static Color Color_Dialog()
        {
            //Exemplo
            // this.BackColor = cyautogui.Run_Dialogs.Color_Dialog();
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.FullOpen = true;
            colorDialog1.AnyColor = true;
            colorDialog1.SolidColorOnly = false;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                return colorDialog1.Color;
            }
            else
                return Color.White;
        }

        public static Font Font_Dialog()
        {
            //Exemplo:
            // this.Font = cyautogui.Run_Dialogs.Font_Dialog();
            FontDialog fontes = new FontDialog();
            fontes.ShowColor = false;
            if (fontes.ShowDialog() != DialogResult.Cancel)
                return fontes.Font;
            else
                return fontes.Font;
        }


    }

    public class Arquivos
    {
        public static bool Arquivo_Existe(string path)
        {
            if (File.Exists(path))
                return true;
            else
                return false;
        }

        public static void Apagar_Arquivo(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public static void Criar_Arquivo(string path)
        {
            File.Create(path);
        }

        public static List<string> ListarArquivos(string pasta)
        {
            //Exemplo:
            /*
              List<string> aa = cyautogui.Pastas.ListarArquivos("E:/");
              for(int i = 0; i <= (aa.Count() - 1); i++) 
                MessageBox.Show(aa[i]); 
            */
            List<string> temp = new List<string>();
            string[] fileEntries = Directory.GetFiles(pasta);
            foreach (string fileName in fileEntries)
                temp.Add(fileName);

            return temp;
        }

        public static void Criptografar(string inputFile, string outputFile, string password)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                FileStream fsIn = new FileStream(inputFile, FileMode.Open);
                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);
                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Erro no processo!", "Error");
            }
        }

        private void Decriptografar(string inputFile, string outputFile, string password)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            RijndaelManaged RMCrypto = new RijndaelManaged();
            CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);
            FileStream fsOut = new FileStream(outputFile, FileMode.Create);
            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);
            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
        }

    }

    public class Pastas
    {
        public static void CriarPasta(string pasta)
        {
            if (Directory.Exists(pasta) == false)
                Directory.CreateDirectory(pasta);
        }

        public static void Deletar_Pasta(string pasta)
        {
            if (Directory.Exists(pasta) == false)
                Directory.Delete(pasta);
        }

        public static List<string> ListarPastas(string pasta)
        {
            //Exemplo:
            /*
              List<string> aa = cyautogui.Pastas.ListarPastas("E:/");
              for(int i = 0; i <= (aa.Count() - 1); i++) 
                MessageBox.Show(aa[i]); 
            */
            List<string> temp = new List<string>();
            string[] fileEntries = Directory.GetDirectories(pasta);
            foreach (string fileName in fileEntries)
                temp.Add(fileName);

            return temp;
        }
    }
}



public class Form_Style
{

    /*
     * Como usar:
     * Form_Style.AutoGui_Form(this);
            Form_Style.AutoGui_Button(button1);
            Form_Style.AutoGui_CheckBox(checkBox1); 
            Form_Style.AutoGui_Radio(radioButton2);
            Form_Style.AutoGui_Label(label1);
            Form_Style.AutoGui_LinkLabel(linkLabel1); 
            Form_Style.AutoGui_GroupBox(groupBox1); 
            Form_Style.AutoGui_ComboBox(comboBox1);  
            Form_Style.AutoGui_TextBox(textBox1); 
            Form_Style.AutoGui_Trackbar(trackBar1); 
            Form_Style.AutoGui_NumericUpDown(numericUpDown1); 
            Form_Style.AutoGui_RichTextBox(richTextBox1); 
    */


    //fundo
    private static int R = 0;
    private static int G = 0;
    private static int B = 0;

    //fonte
    private static int R2 = 255;
    private static int G2 = 111;
    private static int B2 = 0;

    //topp
    private static int R3 = 255;
    private static int G3 = 111;
    private static int B3 = 0;



    private static string Fonte_ = "Times New Roman";

    public static void AutoGui_Form(Form formulario)
    {
        //Como usar:
        // colocar no formload
        // cyautogui.Form_Style.AutoGui_Form(this);
        Panel TOPO = new Panel();
        Label Nome = new Label();
        formulario.BackColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
        formulario.Controls.Add(TOPO);
        formulario.Cursor = System.Windows.Forms.Cursors.Hand;
        formulario.Font = new System.Drawing.Font(Fonte_, 12.25F,
            System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        formulario.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        formulario.HelpButton = true;
        formulario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        formulario.Name = "AutoGui_Form";
        formulario.Opacity = 0.95D;
        formulario.ShowIcon = false;
        formulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        formulario.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        formulario.TopMost = true;

        TOPO.ResumeLayout(false);
        TOPO.PerformLayout();
        formulario.ResumeLayout(false);
        TOPO.BackColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R3)))), ((int)(((byte)(G3)))), ((int)(((byte)(B3)))));
        TOPO.Controls.Add(Nome);
        TOPO.Dock = System.Windows.Forms.DockStyle.Top;
        TOPO.Location = new System.Drawing.Point(0, 0);
        TOPO.Size = new System.Drawing.Size(596, 46);
        TOPO.TabIndex = 0;
        Nome.AutoSize = true;
        Nome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)
            (R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
        Nome.Location = new System.Drawing.Point(13, 13);
        Nome.Size = new System.Drawing.Size(103, 17);
        Nome.TabIndex = 0;
        Nome.Text = formulario.Text;
        Nome.Font = new System.Drawing.Font(Fonte_, 15.2F,
            System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

    }

    public static void AutoGui_Button(Button butao)
    {
        butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_, 11.25F,
            System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.TabIndex = 0;
        butao.UseVisualStyleBackColor = true;
        butao.Margin = new System.Windows.Forms.Padding(6);
    }

    public static void AutoGui_CheckBox(CheckBox butao)
    {
        butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_, 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.TabIndex = 0;
        butao.Margin = new System.Windows.Forms.Padding(6);
        butao.UseVisualStyleBackColor = true;
        butao.BackColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
    }

    public static void AutoGui_Radio(RadioButton butao)
    {
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_,
            11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.TabIndex = 0;
        butao.Margin = new System.Windows.Forms.Padding(6);
        butao.UseVisualStyleBackColor = true;
        butao.BackColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
    }


    public static void AutoGui_Label(Label butao)
    {
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_,
            11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.TabIndex = 0;
        butao.Margin = new System.Windows.Forms.Padding(6);
        butao.BackColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
    }
    public static void AutoGui_LinkLabel(LinkLabel butao)
    {
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_, 11.25F,
            System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.TabIndex = 0;
        butao.BackColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
        butao.LinkColor = Color.White;
        butao.Margin = new System.Windows.Forms.Padding(6);
    }


    public static void AutoGui_GroupBox(GroupBox butao)
    {
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_,
            11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.TabIndex = 0;
        butao.Margin = new System.Windows.Forms.Padding(6);
        butao.BackColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
    }


    public static void AutoGui_ComboBox(ComboBox butao)
    {
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_,
            11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.BackColor = System.Drawing.Color.FromArgb(
           ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
        butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Margin = new System.Windows.Forms.Padding(6);

    }

    public static void AutoGui_ProgressBar(ProgressBar botao)
    {
        botao.Margin = new System.Windows.Forms.Padding(6);
        botao.BackColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
    }

    public static void AutoGui_TextBox(TextBox butao)
    {
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_,
            11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.BackColor = System.Drawing.Color.FromArgb(
           ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));

        butao.Margin = new System.Windows.Forms.Padding(6);
    }
    public static void AutoGui_Trackbar(TrackBar butao)
    {
        butao.Margin = new System.Windows.Forms.Padding(6);
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_, 11.25F,
            System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.BackColor = System.Drawing.Color.FromArgb(
           ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));

    }






    public static void AutoGui_NumericUpDown(NumericUpDown butao)
    {
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_, 11.25F,
            System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.BackColor = System.Drawing.Color.FromArgb(
           ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));

        butao.Margin = new System.Windows.Forms.Padding(6);
    }

    public static void AutoGui_RichTextBox(RichTextBox butao)
    {
        butao.Margin = new System.Windows.Forms.Padding(6);
        // butao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        butao.Font = new System.Drawing.Font(Fonte_, 11.25F,
            System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        butao.ForeColor = System.Drawing.Color.FromArgb(
            ((int)(((byte)(R2)))), ((int)(((byte)(G2)))), ((int)(((byte)(B2)))));
        butao.BackColor = System.Drawing.Color.FromArgb(
           ((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))));
        butao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    }
}
