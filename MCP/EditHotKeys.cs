using System;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;

namespace HBMmacros
{
    public partial class EditHotKeys : Form
    {
        TextBox selectedTB = new TextBox();
        string tbText = "";

        public EditHotKeys()
        {
            InitializeComponent();
            ActiveControl = label1;
            KeyPreview = true;

            foreach (TextBox tb in panel1.Controls.OfType<TextBox>())
            {
                tb.Click += (s, e) =>
                {
                    tbText = tb.Text;
                    tb.Text = "";
                    selectedTB = tb;
                    tb.KeyDown += tb_KeyDown;
                };
                tb.LostFocus += (s, e) =>
                {
                    int qRepeat = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (tb.Text == panel1.Controls.OfType<TextBox>().ToArray()[i].Text)
                            qRepeat++;
                    }
                    if (tb.Text == "Ctrl+" || tb.Text == "Alt+" ||
                        tb.Text == "Shift+" || tb.Text == "" || qRepeat >= 2)
                        tb.Text = tbText;
                };
            }

            TextBox[] tbs = panel1.Controls.OfType<TextBox>().ToArray();
            for (int i = 0; i < 4; i++)
            {
                tbs[i].Text = $"{Program.modifiers[i]}+{HotKeys.FindKeyValue(Program.keys[i].ToString())}";
            }
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control) PrintHotKey(e, "Ctrl+");
            else if (e.Alt) PrintHotKey(e, "Alt+");
            else if (e.Shift) PrintHotKey(e, "Shift+");
        }

        private void PrintHotKey(KeyEventArgs e, string text)
        {
            selectedTB.Text = text;
            if (e.KeyCode.ToString() != "ControlKey" && e.KeyCode.ToString() != "Menu"
                && e.KeyCode.ToString() != "ShiftKey")
            {
                selectedTB.Text += HotKeys.FindKeyValue(e.KeyValue.ToString());
                e.SuppressKeyPress = true;
                KeyDown -= tb_KeyDown;
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            string[] modKey = new string[2];
            TextBox[] tbs = panel1.Controls.OfType<TextBox>().ToArray();
            for (int i = 0; i < 4; i++)
            {
                if (!tbs[i].Text.Contains("Num + "))
                    modKey = tbs[i].Text.Split('+');
                else
                {
                    modKey[0] = tbs[i].Text.Remove(tbs[i].Text.Length - 6);
                    modKey[1] = "Num +";
                }
                Program.modifiers[i] = modKey[0];
                Program.keys[i] = HotKeys.FindKeyCode(modKey[1]);
                RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\HBMmacros");
                reg.SetValue($"Modifier{i}", Program.modifiers[i]);
                reg.SetValue($"Key{i}", Program.keys[i]);
            }
            Close();
        }
    }
}