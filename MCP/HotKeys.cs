using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HBMmacros
{
    [Flags]
    enum Modifiers : uint
    {
        ALT = 0x0001,
        CONTROL = 0x0002,
        SHIFT = 0x0004,
        WIN = 0x0008
    }

    static class HotKeys
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RegisterHotKey(
            IntPtr hWnd,
            int Id,
            Modifiers fsModifiers,
            Keys vk
            );

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnregisterHotKey(
            IntPtr hWnd,
            int Id
            );

        public static bool Register(Form frm, int id,
                                      Modifiers mod,
                                      Keys key)
        {
            if (frm == null || frm.IsDisposed)
                return false;
            if ((uint)mod == 0U)
                return false;
            if (key == Keys.None)
                return false;

            return RegisterHotKey(frm.Handle, id, mod, key);
        }

        public static bool Unregister(Form frm, int id)
        {
            if (frm == null || frm.IsDisposed)
                return false;

            return UnregisterHotKey(frm.Handle, id);
        }

        public static string[,] keyCodes = new string[,]
        {
            {"8", "BackSpace"},
            {"9", "Tab"},
            {"13", "Enter"},
            {"20", "CapsLock"},
            {"27", "Esc"},
            {"32", "Space"},
            {"33", "PageUp"},
            {"34", "PageDown"},
            {"35", "End"},
            {"36", "Home"},
            {"37", "Left"},
            {"38", "Up"},
            {"39", "Right"},
            {"40", "Down"},
            {"44", "PrintScreen"},
            {"45", "Insert"},
            {"46", "Delete"},
            {"48", "0"},
            {"49", "1"},
            {"50", "2"},
            {"51", "3"},
            {"52", "4"},
            {"53", "5"},
            {"54", "6"},
            {"55", "7"},
            {"56", "8"},
            {"57", "9"},
            {"65", "A"},
            {"66", "B"},
            {"67", "C"},
            {"68", "D"},
            {"69", "E"},
            {"70", "F"},
            {"71", "G"},
            {"72", "H"},
            {"73", "I"},
            {"74", "J"},
            {"75", "K"},
            {"76", "L"},
            {"77", "M"},
            {"78", "N"},
            {"79", "O"},
            {"80", "P"},
            {"81", "Q"},
            {"82", "R"},
            {"83", "S"},
            {"84", "T"},
            {"85", "U"},
            {"86", "V"},
            {"87", "W"},
            {"88", "X"},
            {"89", "Y"},
            {"90", "Z"},
            {"96", "Num 0"},
            {"97", "Num 1"},
            {"98", "Num 2"},
            {"99", "Num 3"},
            {"100", "Num 4"},
            {"101", "Num 5"},
            {"102", "Num 6"},
            {"103", "Num 7"},
            {"104", "Num 8"},
            {"105", "Num 9"},
            {"106", "Num *"},
            {"107", "Num +"},
            {"109", "Num -"},
            {"110", "Num ,"},
            {"111", "Num /"},
            {"112", "F1"},
            {"113", "F2"},
            {"114", "F3"},
            {"115", "F4"},
            {"116", "F5"},
            {"117", "F6"},
            {"118", "F7"},
            {"119", "F8"},
            {"120", "F9"},
            {"121", "F10"},
            {"122", "F11"},
            {"123", "F12"},
            {"124", "F13"},
            {"125", "F14"},
            {"126", "F15"},
            {"127", "F16"},
            {"128", "F17"},
            {"129", "F18"},
            {"130", "F19"},
            {"131", "F20"},
            {"132", "F21"},
            {"133", "F22"},
            {"134", "F23"},
            {"135", "F24"},
            {"144", "Numlock"}
        };
    }
}