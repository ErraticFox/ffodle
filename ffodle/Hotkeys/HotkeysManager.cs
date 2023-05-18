using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace ffodle.Hotkeys
{
    class HotkeysManager
    {

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static LowLevelKeyboardProc LowLevelProc = HookCallback;
 
        private static List<GlobalHotKey> HotKeys { get; set; }

        private const int WH_KEYBOARD_LL = 13;


        private static IntPtr HookID = IntPtr.Zero;


        public static bool IsHookSetup { get; set; }


        static HotkeysManager() 
        { 
            HotKeys = new List<GlobalHotKey>();
        }

        public static void SetupSystemHook() 
        {
            if (!IsHookSetup)
            {
                HookID = SetHook(HookCallback);
                IsHookSetup = true;
            }
        }

        public static void ShutdownSystemHook()
        {
            if (IsHookSetup)
            {
                UnhookWindowsHookEx(HookID);
                IsHookSetup = false;
            }
        }
        
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using Process currentProcess = Process.GetCurrentProcess();
            using ProcessModule currentModule = currentProcess.MainModule;
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(currentModule.ModuleName), 0);
        }

        public static void AddHotkey(GlobalHotKey hotkey)
        {
            HotKeys.Add(hotkey);
        }


        public static void RemoveHotkey(GlobalHotKey hotkey)
        {
            HotKeys.Remove(hotkey);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                foreach (GlobalHotKey hotkey in HotKeys)
                {
                    if (Control.ModifierKeys == hotkey.Modifier && Keyboard.IsKeyDown(hotkey.Key))
                    {
                        if (hotkey.CanExecute)
                        {
                            hotkey.Callback?.Invoke();
                        }
                    }
                }
            }

            return CallNextHookEx(HookID, nCode, wParam, lParam);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}
