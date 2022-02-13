using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rope.Helpers
{
    public class KeyBindHelper
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys key);


        public static bool KeyHasBeenPressed(Keys key)
        {
            byte[] result = BitConverter.GetBytes(GetAsyncKeyState(key));

            if (result[0] == 1)
                return true;

            return false;
        }
        public static bool IsKeyDown(Keys key)
        {
            return GetAsyncKeyState(key) != 0;
        }
    }
}
