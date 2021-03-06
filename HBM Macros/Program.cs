﻿using System;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HBMmacros
{
    static class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RegisterHotKey(IntPtr hWnd, int Id, Modifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnregisterHotKey(IntPtr hWnd, int Id);

        [STAThread]
        static int Main (string[] args) {
            if (System.Diagnostics.Process.GetProcessesByName(Application.ProductName).Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                modifiers = new string[4];
                keys = new int[4];

                Form frm = new frmMain();
                fHandle = frm.Handle;
                frm.FormClosed += (s, e) =>
                {
                    for (int i = 0; i < 4; i++)
                    {
                        UnregisterHotKey(fHandle, i);
                    }
                };

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
                            Form settings = new Settings();
                            settings.Show();
                        }),
                        new MenuItem("Help", (s, e) =>
                        {
                            Form help = new Help();
                            help.Show();
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
                            for (int i = 0; i < 4; i++)
                            {
                                modifiers[i] = key.GetValue($"Modifier{i}").ToString();
                                keys[i] = (int)key.GetValue($"Key{i}");
                            }
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
                        for (int i = 0, j = 49; i < 4; i++, j++)
                        {
                            modifiers[i] = "Alt";
                            keys[i] = j;
                        }
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

                    for (int i = 0; i < 4; i++)
                    {
                        switch (modifiers[i])
                        {
                            case "Alt":
                                RegisterHotKey(fHandle, i, Modifiers.ALT, (Keys)keys[i]);
                                break;
                            case "Ctrl":
                                RegisterHotKey(fHandle, i, Modifiers.CONTROL, (Keys)keys[i]);
                                break;
                            case "Shift":
                                RegisterHotKey(fHandle, i, Modifiers.SHIFT, (Keys)keys[i]);
                                break;
                        }
                    }

                    icon.Visible = true;
                    icon.ShowBalloonTip(100, "HBM Macros", "Приложение успешно запущено!", ToolTipIcon.None);
                    Application.Run();
                    icon.Visible = false;
                }
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
        public static string[] modifiers { get; set; }
        public static int[] keys { get; set; }
        public static IntPtr fHandle { get; set; }
    }
}