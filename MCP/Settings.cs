using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace HBMmacros
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
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
    }
}
