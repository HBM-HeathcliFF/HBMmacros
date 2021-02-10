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
                for (int j = 0; j < 93; j++)
                {
                    if (Program.keys[i].ToString() == HotKeys.keyCodes[j, 0])
                    {
                        tbs[i].Text = $"{Program.modifiers[i]}+{HotKeys.keyCodes[j, 1]}";
                        break;
                    }
                }
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
                for (int i = 0; i < 93; i++)
                {
                    if (e.KeyValue.ToString() == HotKeys.keyCodes[i, 0])
                    {
                        selectedTB.Text += HotKeys.keyCodes[i, 1];
                        break;
                    }
                }
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
                for (int j = 0; j < 93; j++)
                {
                    if (modKey[1] == HotKeys.keyCodes[j, 1])
                    {
                        Program.keys[i] = Convert.ToInt32(HotKeys.keyCodes[j, 0]);
                        break;
                    }
                }
                RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\HBMmacros");
                reg.SetValue($"Modifier{i}", Program.modifiers[i]);
                reg.SetValue($"Key{i}", Program.keys[i]);
            }
            Close();
        }
    }
}