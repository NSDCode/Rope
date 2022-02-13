using Rope.Helpers;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Rope
{

    public enum KeyBindModes
    {
        SINGLE,
        MULTI,
    }
    public enum CheckModes
    {
        PRESSED,
        DOWN,
    }

    public class KeyBindHandler
    {
        public List<Keys> keyBinds = new List<Keys>();
        public Keys keyBind = Keys.None;
        
        private KeyBindModes keyBindMode;
        private CheckModes checkMode;

        private bool bindState;
        private bool threadState;
        private bool isBackground;

        private int delay;

        #region constructors

        /// <summary>Constructor <c>KeyBindHandler</c>Let you create a KeyBindHandler
        /// KeyBind/KeyBinds: One key or List of Keys to be checked
        /// checkMode: PRESSED: Checks if the key have been pressed before
        ///            DOWN: Checks if the key is being held down
        /// isBackground: To set the thread IsBackground variable
        /// delay: delay of checks (default 50)</summary>
        public KeyBindHandler(List<Keys> keyBinds, CheckModes checkMode, bool isBackground = false, int delay = 50)
        {
            this.keyBinds = keyBinds;
            this.keyBindMode = KeyBindModes.MULTI;
            this.checkMode = checkMode;
            this.isBackground = isBackground;
            this.delay = delay;
        }

        public KeyBindHandler(Keys keyBind, CheckModes checkMode, bool isBackground = false, int delay = 10)
        {
            this.keyBind = keyBind;
            this.keyBindMode = KeyBindModes.SINGLE;
            this.checkMode = checkMode;
            this.isBackground = isBackground;
            this.delay = delay;
        }
        #endregion
        /// <summary>method <c>Start</c>Start the thread of the handler.</summary>
        public void Start()
        {
            Thread mainThread = new Thread(KeyBindThread);
            mainThread.IsBackground = this.isBackground;
            this.threadState = true;
            mainThread.Start();
        }

        ///<summary>method <c>Stop</c>Stops the thread of the handler.</summary>
        public void Stop() => this.threadState = false;

        public bool GetBindState() => this.bindState;
        public void SetDelay(int delay) => this.delay = delay;
        public int GetDelay() => this.delay;

        private void CheckState()
        {
            // will check the keybind states accordingly to consturctor settings.
            switch (keyBindMode)
            {
                case KeyBindModes.SINGLE:

                    switch (this.checkMode)
                    {
                        case CheckModes.PRESSED:
                            if (KeyBindHelper.KeyHasBeenPressed(this.keyBind))
                                this.bindState = !this.bindState;
                            break;
                        case CheckModes.DOWN:
                            if (KeyBindHelper.IsKeyDown(this.keyBind))
                                this.bindState = !this.bindState;
                        break;
                    }

                    break;
                case KeyBindModes.MULTI:
                    foreach (Keys key in this.keyBinds)
                    {
                        switch (this.checkMode)
                        {
                            case CheckModes.PRESSED:
                                if (KeyBindHelper.KeyHasBeenPressed(key))
                                {
                                    this.bindState = !this.bindState;
                                    break;
                                }
                                break;
                            case CheckModes.DOWN:
                                if (KeyBindHelper.IsKeyDown(key))
                                {
                                    this.bindState = !this.bindState;
                                    break;
                                }
                                break;
                        }
                    }
                    break;
                
            }
        }


        private void KeyBindThread()
        {
            // main thread
            while (this.threadState)
            {
                CheckState();
                Thread.Sleep(this.delay);
            }
        }


    }
}
