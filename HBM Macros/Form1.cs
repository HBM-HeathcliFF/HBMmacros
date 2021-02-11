using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HBMmacros
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKLID, uint Flags);

        const int WM_HOTKEY = 0x0312;

        async void foo(Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                if (m.WParam.ToString() == "0")
                {
                    gunMacros(1);
                }
                if (m.WParam.ToString() == "1")
                {
                    gunMacros(2);
                }
                if (m.WParam.ToString() == "2")
                {
                    gunMacros(3);
                }
                if (m.WParam.ToString() == "3")
                {
                    await Task.Delay(Program.delay);
                    SendKeys.SendWait("{Up 17}");
                    await Task.Delay(Program.delay);
                    SendKeys.SendWait("{Down 6}");
                    await Task.Delay(Program.delay);
                    if (Program.isMheal)
                    {
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                    }    
                    if (Program.isHeal)
                    {
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{Down}");
                        await Task.Delay(Program.delay);
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                        await Task.Delay(Program.delay);
                    }
                    if (Program.isMask)
                    {
                        if (!Program.isHeal)
                        {
                            await Task.Delay(Program.delay);
                            SendKeys.SendWait("{Down}");
                        }
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{Down}");
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{Up 4}");
                        await Task.Delay(Program.delay);
                        if (Program.numberMask == 2)
                        {
                            SendKeys.SendWait("{Down}");
                            await Task.Delay(Program.delay);
                        }
                        if (Program.numberMask == 3)
                        {
                            SendKeys.SendWait("{Down 2}");
                            await Task.Delay(Program.delay);
                        }
                        if (Program.numberMask == 4)
                        {
                            SendKeys.SendWait("{Down 3}");
                            await Task.Delay(Program.delay);
                        }
                        if (Program.numberMask == 5)
                        {
                            SendKeys.SendWait("{Down 4}");
                            await Task.Delay(Program.delay);
                        }
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ENTER}");
                        await Task.Delay(Program.delay);
                        SendKeys.SendWait("{ESC}");
                    }
                    await Task.Delay(Program.delay);
                    SendKeys.SendWait("{ESC}");
                }
            }
        }

        async void gunMacros(int number)
        {
            string lang = "00000409";
            int ret = LoadKeyboardLayout(lang, 1);
            PostMessage(GetForegroundWindow(), 0x50, 1, ret);

            SendKeys.SendWait("{F6}");
            await Task.Delay(Program.delay);
            SendKeys.SendWait("/mn");
            await Task.Delay(Program.delay);
            SendKeys.SendWait("{ENTER}");
            await Task.Delay(Program.delay);
            await Task.Delay(Program.delay);
            SendKeys.SendWait("{Down 15}");
            await Task.Delay(Program.delay);
            SendKeys.SendWait("{Up 4}");
            await Task.Delay(Program.delay);
            await Task.Delay(Program.delay);
            SendKeys.SendWait("{ENTER}");
            await Task.Delay(Program.delay);
            await Task.Delay(Program.delay);
            SendKeys.SendWait("{Up 2}");
            await Task.Delay(Program.delay);
            if (number == 2)
            {
                SendKeys.SendWait("{Down}");
                await Task.Delay(Program.delay);
            }
            if (number == 3)
            {
                SendKeys.SendWait("{Down 2}");
                await Task.Delay(Program.delay);
            }
            SendKeys.SendWait("{ENTER}");
            await Task.Delay(Program.delay);
            await Task.Delay(Program.delay);
            SendKeys.SendWait("^{HOME}");
            await Task.Delay(Program.delay);
            SendKeys.SendWait("^+{END}");
            await Task.Delay(Program.delay);
            SendKeys.SendWait("{DEL}");
            
            await Task.Delay(Program.delay);
            if (number == 1) SendKeys.SendWait($"{Program.g1AmmoCount}");
            if (number == 2) SendKeys.SendWait($"{Program.g2AmmoCount}");
            if (number == 3) SendKeys.SendWait($"{Program.g3AmmoCount}");
            await Task.Delay(Program.delay);
            await Task.Delay(Program.delay);
            SendKeys.SendWait("{ENTER}");
        }
        public frmMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        protected override void WndProc(ref Message m)
        {
            foo(m);
            base.WndProc(ref m);
        }
    }
}