using PadControlHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadControllHelper {
    public class KeyList {
        public static Dictionary<string, KeyInfo> keyList = new Dictionary<string, KeyInfo>();

        public static void initKeyList() {
            //keyList.Add(new KeyCode("Mouse LButton", Keys.LButton));
            //keyList.Add(new KeyCode("Mouse RButton", Keys.RButton));
            //keyList.Add(new KeyCode("Mouse MButton", Keys.MButton));
            //keyList.Add(new KeyCode("Mouse XButton1", Keys.XButton1));
            //keyList.Add(new KeyCode("Mouse XButton2", Keys.XButton2));
            keyList.Add(KeyInfo.NUMPAD_0, new KeyInfo(KeyInfo.NUMPAD_0, Keys.NumPad0));
            keyList.Add(KeyInfo.NUMPAD_1, new KeyInfo(KeyInfo.NUMPAD_1, Keys.NumPad1));
            keyList.Add(KeyInfo.NUMPAD_2, new KeyInfo(KeyInfo.NUMPAD_2, Keys.NumPad2));
            keyList.Add(KeyInfo.NUMPAD_3, new KeyInfo(KeyInfo.NUMPAD_3, Keys.NumPad3));
            keyList.Add(KeyInfo.NUMPAD_4, new KeyInfo(KeyInfo.NUMPAD_4, Keys.NumPad4));
            keyList.Add(KeyInfo.NUMPAD_5, new KeyInfo(KeyInfo.NUMPAD_5, Keys.NumPad5));
            keyList.Add(KeyInfo.NUMPAD_6, new KeyInfo(KeyInfo.NUMPAD_6, Keys.NumPad6));
            keyList.Add(KeyInfo.NUMPAD_7, new KeyInfo(KeyInfo.NUMPAD_7, Keys.NumPad7));
            keyList.Add(KeyInfo.NUMPAD_8, new KeyInfo(KeyInfo.NUMPAD_8, Keys.NumPad8));
            keyList.Add(KeyInfo.NUMPAD_9, new KeyInfo(KeyInfo.NUMPAD_9, Keys.NumPad9));
            keyList.Add(KeyInfo.D_0, new KeyInfo(KeyInfo.D_0, Keys.D0));
            keyList.Add(KeyInfo.D_1, new KeyInfo(KeyInfo.D_1, Keys.D1));
            keyList.Add(KeyInfo.D_2, new KeyInfo(KeyInfo.D_2, Keys.D2));
            keyList.Add(KeyInfo.D_3, new KeyInfo(KeyInfo.D_3, Keys.D3));
            keyList.Add(KeyInfo.D_4, new KeyInfo(KeyInfo.D_4, Keys.D4));
            keyList.Add(KeyInfo.D_5, new KeyInfo(KeyInfo.D_5, Keys.D5));
            keyList.Add(KeyInfo.D_6, new KeyInfo(KeyInfo.D_6, Keys.D6));
            keyList.Add(KeyInfo.D_7, new KeyInfo(KeyInfo.D_7, Keys.D7));
            keyList.Add(KeyInfo.D_8, new KeyInfo(KeyInfo.D_8, Keys.D8));
            keyList.Add(KeyInfo.D_9, new KeyInfo(KeyInfo.D_9, Keys.D9));
            keyList.Add(KeyInfo.ADD, new KeyInfo(KeyInfo.ADD, Keys.Add));
            keyList.Add(KeyInfo.MULTIPLY, new KeyInfo(KeyInfo.MULTIPLY, Keys.Multiply));
            keyList.Add(KeyInfo.MINUS, new KeyInfo(KeyInfo.MINUS, Keys.Subtract));
            keyList.Add(KeyInfo.DECIMAL, new KeyInfo(KeyInfo.DECIMAL, Keys.Decimal));
            keyList.Add(KeyInfo.DEVIDE, new KeyInfo(KeyInfo.DEVIDE, Keys.Divide));
            keyList.Add(KeyInfo.F1, new KeyInfo(KeyInfo.F1, Keys.F1));
            keyList.Add(KeyInfo.F2, new KeyInfo(KeyInfo.F2, Keys.F2));
            keyList.Add(KeyInfo.F3, new KeyInfo(KeyInfo.F3, Keys.F3));
            keyList.Add(KeyInfo.F4, new KeyInfo(KeyInfo.F4, Keys.F4));
            keyList.Add(KeyInfo.F5, new KeyInfo(KeyInfo.F5, Keys.F5));
            keyList.Add(KeyInfo.F6, new KeyInfo(KeyInfo.F6, Keys.F6));
            keyList.Add(KeyInfo.F7, new KeyInfo(KeyInfo.F7, Keys.F7));
            keyList.Add(KeyInfo.F8, new KeyInfo(KeyInfo.F8, Keys.F8));
            keyList.Add(KeyInfo.F9, new KeyInfo(KeyInfo.F9, Keys.F9));
            keyList.Add(KeyInfo.F10, new KeyInfo(KeyInfo.F10, Keys.F10));
            keyList.Add(KeyInfo.F11, new KeyInfo(KeyInfo.F11, Keys.F11));
            keyList.Add(KeyInfo.F12, new KeyInfo(KeyInfo.F12, Keys.F12));
            keyList.Add(KeyInfo.F13, new KeyInfo(KeyInfo.F13, Keys.F13));
            keyList.Add(KeyInfo.F14, new KeyInfo(KeyInfo.F14, Keys.F14));
            keyList.Add(KeyInfo.F15, new KeyInfo(KeyInfo.F15, Keys.F15));
            keyList.Add(KeyInfo.F16, new KeyInfo(KeyInfo.F16, Keys.F16));
            keyList.Add(KeyInfo.F17, new KeyInfo(KeyInfo.F17, Keys.F17));
            keyList.Add(KeyInfo.F18, new KeyInfo(KeyInfo.F18, Keys.F18));
            keyList.Add(KeyInfo.F19, new KeyInfo(KeyInfo.F19, Keys.F19));
            keyList.Add(KeyInfo.F20, new KeyInfo(KeyInfo.F20, Keys.F20));
            keyList.Add(KeyInfo.F21, new KeyInfo(KeyInfo.F21, Keys.F21));
            keyList.Add(KeyInfo.F22, new KeyInfo(KeyInfo.F22, Keys.F22));
            keyList.Add(KeyInfo.F23, new KeyInfo(KeyInfo.F23, Keys.F23));
            keyList.Add(KeyInfo.BACKSPACE, new KeyInfo(KeyInfo.BACKSPACE, Keys.Back));
            keyList.Add(KeyInfo.TAB, new KeyInfo(KeyInfo.TAB, Keys.Tab));
            keyList.Add(KeyInfo.ENTER, new KeyInfo(KeyInfo.ENTER, Keys.Enter));
            keyList.Add(KeyInfo.LEFT_SHIFT, new KeyInfo(KeyInfo.LEFT_SHIFT, Keys.LShiftKey));
            keyList.Add(KeyInfo.RIGHT_SHIFT, new KeyInfo(KeyInfo.RIGHT_SHIFT, Keys.RShiftKey));
            keyList.Add(KeyInfo.CONTROL, new KeyInfo(KeyInfo.CONTROL, Keys.ControlKey));
            keyList.Add(KeyInfo.L_CONTROL, new KeyInfo(KeyInfo.L_CONTROL, Keys.LControlKey));
            keyList.Add(KeyInfo.R_CONTROL, new KeyInfo(KeyInfo.R_CONTROL, Keys.RControlKey));
            keyList.Add(KeyInfo.ALT, new KeyInfo(KeyInfo.ALT, Keys.Alt));
            keyList.Add(KeyInfo.LMENU, new KeyInfo(KeyInfo.LMENU, Keys.LMenu));
            keyList.Add(KeyInfo.KANAMODE, new KeyInfo(KeyInfo.KANAMODE, Keys.KanaMode));
            keyList.Add(KeyInfo.KANJIMODE, new KeyInfo(KeyInfo.KANJIMODE, Keys.KanjiMode));
            keyList.Add(KeyInfo.APPS, new KeyInfo(KeyInfo.APPS, Keys.Apps));
            keyList.Add(KeyInfo.CAPS_LOCK, new KeyInfo(KeyInfo.CAPS_LOCK, Keys.CapsLock));
            keyList.Add(KeyInfo.ESC, new KeyInfo(KeyInfo.ESC, Keys.Escape));
            keyList.Add(KeyInfo.SPACE, new KeyInfo(KeyInfo.SPACE, Keys.Space));
            keyList.Add(KeyInfo.PAGEUP, new KeyInfo(KeyInfo.PAGEUP, Keys.PageUp));
            keyList.Add(KeyInfo.PAGEDOWN, new KeyInfo(KeyInfo.PAGEDOWN, Keys.PageDown));
            keyList.Add(KeyInfo.END, new KeyInfo(KeyInfo.END, Keys.End));
            keyList.Add(KeyInfo.HOME, new KeyInfo(KeyInfo.HOME, Keys.Home));
            keyList.Add(KeyInfo.LEFT, new KeyInfo(KeyInfo.LEFT, Keys.Left));
            keyList.Add(KeyInfo.RIGHT, new KeyInfo(KeyInfo.RIGHT, Keys.Right));
            keyList.Add(KeyInfo.UP, new KeyInfo(KeyInfo.UP, Keys.Up));
            keyList.Add(KeyInfo.DOWN, new KeyInfo(KeyInfo.DOWN, Keys.Down));
            keyList.Add(KeyInfo.INSERT, new KeyInfo(KeyInfo.INSERT, Keys.Insert));
            keyList.Add(KeyInfo.DELETE, new KeyInfo(KeyInfo.DELETE, Keys.Delete));
            keyList.Add(KeyInfo.NUMLOCK, new KeyInfo(KeyInfo.NUMLOCK, Keys.NumLock));
            keyList.Add(KeyInfo.PRINTSCREEN, new KeyInfo(KeyInfo.PRINTSCREEN, Keys.PrintScreen));
            keyList.Add(KeyInfo.SCROLL_LOCK, new KeyInfo(KeyInfo.SCROLL_LOCK, Keys.Scroll));
            keyList.Add(KeyInfo.PAUSE_BREAK, new KeyInfo(KeyInfo.PAUSE_BREAK, Keys.Pause));
            keyList.Add(KeyInfo.MENU, new KeyInfo(KeyInfo.MENU, Keys.Menu));
            keyList.Add(KeyInfo.MEDIANEXTTRACK, new KeyInfo(KeyInfo.MEDIANEXTTRACK, Keys.MediaNextTrack));
            keyList.Add(KeyInfo.MEDIAPLAYPAUSE, new KeyInfo(KeyInfo.MEDIAPLAYPAUSE, Keys.MediaPlayPause));
            keyList.Add(KeyInfo.MEDIAPREVIOUSTRACK, new KeyInfo(KeyInfo.MEDIAPREVIOUSTRACK, Keys.MediaPreviousTrack));
            keyList.Add(KeyInfo.MEDIASTOP, new KeyInfo(KeyInfo.MEDIASTOP, Keys.MediaStop));
            keyList.Add(KeyInfo.VOLUMEMUTE, new KeyInfo(KeyInfo.VOLUMEMUTE, Keys.VolumeMute));
            keyList.Add(KeyInfo.VOLUMEDOWN, new KeyInfo(KeyInfo.VOLUMEDOWN, Keys.VolumeDown));
            keyList.Add(KeyInfo.VOLUMEUP, new KeyInfo(KeyInfo.VOLUMEUP, Keys.VolumeUp));
            keyList.Add(KeyInfo.BROWSERBACK, new KeyInfo(KeyInfo.BROWSERBACK, Keys.BrowserBack));
            keyList.Add(KeyInfo.BROWSERFORWARD, new KeyInfo(KeyInfo.BROWSERFORWARD, Keys.BrowserForward));
            keyList.Add(KeyInfo.BROWSERREFRESH, new KeyInfo(KeyInfo.BROWSERREFRESH, Keys.BrowserRefresh));
            keyList.Add(KeyInfo.BROWSERSTOP, new KeyInfo(KeyInfo.BROWSERSTOP, Keys.BrowserStop));
            keyList.Add(KeyInfo.BROWSERSEARCH, new KeyInfo(KeyInfo.BROWSERSEARCH, Keys.BrowserSearch));
            keyList.Add(KeyInfo.BROWSERFAVORITES, new KeyInfo(KeyInfo.BROWSERFAVORITES, Keys.BrowserFavorites));
            keyList.Add(KeyInfo.BROWSERHOME, new KeyInfo(KeyInfo.BROWSERHOME, Keys.BrowserHome));
            keyList.Add(KeyInfo.LWIN, new KeyInfo(KeyInfo.LWIN, Keys.LWin));
            keyList.Add(KeyInfo.RWIN, new KeyInfo(KeyInfo.RWIN, Keys.RWin));
        }

        public static KeyInfo? getKeyInfo(int keyCode) {
            foreach(KeyValuePair<string, KeyInfo> kv in keyList)
                if((int)kv.Value.key == keyCode) {
                    return kv.Value;
                }
            return null;
        }
    }
}
