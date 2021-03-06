﻿using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HBMmacros
{
    public partial class Settings : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RegisterHotKey(IntPtr hWnd, int Id, Modifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnregisterHotKey(IntPtr hWnd, int Id);
        public Settings()
        {
            InitializeComponent();
            ActiveControl = label1;
            tbd.Text = Program.delay.ToString();
            tbg1.Text = Program.g1AmmoCount.ToString();
            tbg2.Text = Program.g2AmmoCount.ToString();
            tbg3.Text = Program.g3AmmoCount.ToString();
            healCB.Checked = Program.isHeal;
            mhealCB.Checked = Program.isMheal;
            maskCB.Checked = Program.isMask;
            if (Program.numberMask == 1) defaultRB.Checked = true;
            if (Program.numberMask == 2) whiteRB.Checked = true;
            if (Program.numberMask == 3) redRB.Checked = true;
            if (Program.numberMask == 4) greenRB.Checked = true;
            if (Program.numberMask == 5) blackRB.Checked = true;
            if (Program.isSaved) rememberCB.Checked = true;
            else rememberCB.Checked = false;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Program.delay = Convert.ToInt32(tbd.Text);
            Program.g1AmmoCount = Convert.ToInt32(tbg1.Text);
            Program.g2AmmoCount = Convert.ToInt32(tbg2.Text);
            Program.g3AmmoCount = Convert.ToInt32(tbg3.Text);
            Program.isHeal = healCB.Checked;
            Program.isMheal = mhealCB.Checked;
            Program.isMask = maskCB.Checked;
            if (defaultRB.Checked) Program.numberMask = 1;
            if (whiteRB.Checked) Program.numberMask = 2;
            if (redRB.Checked) Program.numberMask = 3;
            if (greenRB.Checked) Program.numberMask = 4;
            if (blackRB.Checked) Program.numberMask = 5;
            if (rememberCB.Checked)
            {
                RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\HBMmacros");
                for (int i = 0; i < 4; i++)
                {
                    reg.SetValue($"Modifier{i}", Program.modifiers[i]);
                    reg.SetValue($"Key{i}", Program.keys[i]);
                }
                reg.SetValue("Delay", Program.delay);
                reg.SetValue("g1AmmoCount", Program.g1AmmoCount);
                reg.SetValue("g2AmmoCount", Program.g2AmmoCount);
                reg.SetValue("g3AmmoCount", Program.g3AmmoCount);
                if (Program.isHeal) reg.SetValue("Heal", 1);
                else reg.SetValue("Heal", 0);
                if (Program.isMheal) reg.SetValue("Mheal", 1);
                else reg.SetValue("Mheal", 0);
                if (Program.isMask) reg.SetValue("Mask", 1);
                else reg.SetValue("Mask", 0);
                reg.SetValue("NumberMask", Program.numberMask);
            }
            else
            {
                try
                {
                    Registry.CurrentUser.DeleteSubKeyTree("Software\\HBMmacros");
                }
                catch (Exception) { }
            }
            Close();
        }

        private void rememberCB_CheckedChanged(object sender, EventArgs e)
        {
            if (rememberCB.Checked) Program.isSaved = true;
            else Program.isSaved = false;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Form Edit = new EditHotKeys();
            for (int i = 0; i < 4; i++)
            {
                UnregisterHotKey(Program.fHandle, i);
            }
            Enabled = false;
            Edit.Show();
            Edit.FormClosed += (s1, e1) =>
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (Program.modifiers[i])
                    {
                        case "Alt":
                            RegisterHotKey(Program.fHandle, i, Modifiers.ALT, (Keys)Program.keys[i]);
                            break;
                        case "Ctrl":
                            RegisterHotKey(Program.fHandle, i, Modifiers.CONTROL, (Keys)Program.keys[i]);
                            break;
                        case "Shift":
                            RegisterHotKey(Program.fHandle, i, Modifiers.SHIFT, (Keys)Program.keys[i]);
                            break;
                    }
                }
                Enabled = true;
            };
        }
    }
}