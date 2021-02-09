using System;
using System.Windows.Forms;

namespace HBMmacros
{
    public partial class EditHotKeys : Form
    {
        TextBox selectedTB = new TextBox();

        public EditHotKeys()
        {
            InitializeComponent();
            ActiveControl = label1;
            KeyPreview = true;
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                selectedTB.Text = "Ctrl+";
                if (e.KeyCode.ToString() != "ControlKey" && e.KeyCode.ToString() != "Menu"
                    && e.KeyCode.ToString() != "ShiftKey")
                {
                    selectedTB.Text += e.KeyCode;
                    e.SuppressKeyPress = true;
                    KeyDown -= tb_KeyDown;
                }
            }
            else if (e.Alt)
            {
                selectedTB.Text = "Alt+";
                if (e.KeyCode.ToString() != "ControlKey" && e.KeyCode.ToString() != "Menu"
                    && e.KeyCode.ToString() != "ShiftKey")
                {
                    selectedTB.Text += e.KeyCode.ToString();
                    e.SuppressKeyPress = true;
                    KeyDown -= tb_KeyDown;
                }
            }
            else if (e.Shift)
            {
                selectedTB.Text = "Shift+";
                if (e.KeyCode.ToString() != "ControlKey" && e.KeyCode.ToString() != "Menu"
                    && e.KeyCode.ToString() != "ShiftKey")
                {
                    selectedTB.Text += e.KeyCode.ToString();
                    e.SuppressKeyPress = true;
                    KeyDown -= tb_KeyDown;
                }
            }
        }

        private void tbw1_Click(object sender, EventArgs e)
        {
            tbw1.Text = "";
            selectedTB = tbw1;
            tbw1.KeyDown += tb_KeyDown;
        }

        private void tbw2_Click(object sender, EventArgs e)
        {
            tbw2.Text = "";
            selectedTB = tbw2;
            tbw2.KeyDown += tb_KeyDown;
        }

        private void tbw3_Click(object sender, EventArgs e)
        {
            tbw3.Text = "";
            selectedTB = tbw3;
            tbw3.KeyDown += tb_KeyDown;
        }

        private void tbhm_Click(object sender, EventArgs e)
        {
            tbhm.Text = "";
            selectedTB = tbhm;
            tbhm.KeyDown += tb_KeyDown;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {

        }
    }
}