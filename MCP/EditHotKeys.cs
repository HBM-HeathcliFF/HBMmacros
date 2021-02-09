using System;
using System.Windows.Forms;
using System.Linq;

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
            foreach (TextBox tb in panel1.Controls.OfType<TextBox>())
            {
                tb.Click += (s, e) =>
                {
                    tb.Text = "";
                    selectedTB = tb;
                    tb.KeyDown += tb_KeyDown;
                };
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
                selectedTB.Text += e.KeyCode.ToString(); //Плюсуем по кейкоду символ с библиотеки
                e.SuppressKeyPress = true;
                KeyDown -= tb_KeyDown;
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {

        }
    }
}