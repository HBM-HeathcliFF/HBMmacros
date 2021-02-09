using System;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;

namespace HBMmacros
{
    static class Program
    {
        [STAThread]
        static int Main (string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var frm = new frmMain();
            frm.FormClosed += (s, e) => 
            {
                for (int i = 0; i < 4; i++)
                {
                    HotKeys.Unregister(frm, i);
                }
            };

            HotKeys.Register(frm, 0, Modifiers.ALT, Keys.D1);
            HotKeys.Register(frm, 1, Modifiers.ALT, Keys.D2);
            HotKeys.Register(frm, 2, Modifiers.ALT, Keys.D3);
            HotKeys.Register(frm, 3, Modifiers.ALT, Keys.D4);
            using (NotifyIcon icon = new NotifyIcon())
            {
                icon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                icon.ContextMenu = new ContextMenu(
                    new[]
                    {
                        new MenuItem("Autorun", (s, e) =>
                        {
                            const string name = "HBMmacros";
                            string ExePath = Application.ExecutablePath;
                            RegistryKey reg;
                            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                            try
                            {
                                if (!icon.ContextMenu.MenuItems[0].Checked)
                                {
                                    reg.SetValue(name, ExePath);
                                    icon.ContextMenu.MenuItems[0].Checked = true;
                                }
                                else
                                {
                                    reg.DeleteValue(name);
                                    icon.ContextMenu.MenuItems[0].Checked = false;
                                }
                                reg.Close();
                            }
                            catch { }
                        }),
                        new MenuItem("Settings", (s, e) =>
                        {
                            Form f = new Settings();
                            f.Show();
                        }),
                        new MenuItem("Exit", (s, e) => Application.Exit())
                    });
                try
                {
                    using (var key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\"))
                    {
                        if ((string)key.GetValue("HBMmacros") == Application.ExecutablePath)
                            icon.ContextMenu.MenuItems[0].Checked = true;
                    }
                }
                catch (Exception)
                {
                    icon.ContextMenu.MenuItems[0].Checked = false;
                }

                try
                {
                    using (var key = Registry.CurrentUser.OpenSubKey("Software\\HBMmacros"))
                    {
                        delay = (int)key.GetValue("Delay");
                        g1AmmoCount = (int)key.GetValue("g1AmmoCount");
                        g2AmmoCount = (int)key.GetValue("g2AmmoCount");
                        g3AmmoCount = (int)key.GetValue("g3AmmoCount");
                        if ((int)key.GetValue("Heal") == 1) isHeal = true;
                        else isHeal = false;
                        if ((int)key.GetValue("Mheal") == 1) isMheal = true;
                        else isMheal = false;
                        if ((int)key.GetValue("Mask") == 1) isMask = true;
                        else isMask = false;
                        numberMask = (int)key.GetValue("NumberMask");
                        isSaved = true;
                    }
                }
                catch (Exception)
                {
                    delay = 50;
                    g1AmmoCount = 10;
                    g2AmmoCount = 10;
                    g3AmmoCount = 10;
                    isHeal = true;
                    isMheal = true;
                    isMask = false;
                    numberMask = 1;
                    isSaved = false;
                }

                icon.Visible = true;
                icon.ShowBalloonTip(100, "HBM Macros", "Приложение успешно запущено!", ToolTipIcon.None);
                Application.Run();
                icon.Visible = false;
            }
            return 0;
        }
        public static int delay { get; set; }
        public static int g1AmmoCount { get; set; }
        public static int g2AmmoCount { get; set; }
        public static int g3AmmoCount { get; set; }
        public static bool isHeal { get; set; }
        public static bool isMheal { get; set; }
        public static bool isMask { get; set; }
        public static int numberMask { get; set; }
        public static bool isSaved { get; set; }
        public static uint Modifier { get; set; }
        public static Keys Key { get; set; }
    }
}