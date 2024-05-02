using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadControlHelper {
    public class Macro {
        public int id { get; set; }
        public string title { get; set; }
        public int pointX { get; set; } = 0;
        public int pointY { get; set; } = 0;
        public MacroAction action { get; set; } = 0;
        public KeyInfo keyInfo { get; set; }
        public Variable? variable { get; set; }
        public ActivateCondition activateCondition { get; set; }
        public bool power { get; set; } = true;
        public Variable? changeAfterVar { get; set; }
        public ActivateCondition changeValueTo {  get; set; }

        public string? runFilePath { get; set; }

        public Macro(string title, int pointX, int pointY, MacroAction action, KeyInfo shortCut, Variable? variable, ActivateCondition activateWhen, bool power, Variable? changeAfterVar, ActivateCondition changeValueTo, string? runfilePath, int id = -1) {
            this.title = title;
            this.pointX = pointX;
            this.pointY = pointY;
            this.action = action;
            this.keyInfo = shortCut;
            this.variable = variable;
            this.activateCondition = activateWhen;
            this.power = power;
            this.changeAfterVar = changeAfterVar;
            this.changeValueTo = changeValueTo;
            this.runFilePath = runfilePath;
            this.id = id;   
        }
    }

    public enum MacroAction {
        CLICK = 0,
        RIGHT_CLICK = 1,
        L_DOUBLE_CLICK = 2,
        R_DOUBLE_CLICK = 3,
        M_CLICK = 4,
        M_DOUBLE_CLICK = 5,
        WHEEL_UP = 6,
        WHEEL_DOWN = 7,
        RUN_PROGRAM = 8,
    }

    public class KeyInfo {
        public const string NUMPAD_0 = "Numpad 0";
        public const string NUMPAD_1 = "Numpad 1";
        public const string NUMPAD_2 = "Numpad 2";
        public const string NUMPAD_3 = "Numpad 3";
        public const string NUMPAD_4 = "Numpad 4";
        public const string NUMPAD_5 = "Numpad 5";
        public const string NUMPAD_6 = "Numpad 6";
        public const string NUMPAD_7 = "Numpad 7";
        public const string NUMPAD_8 = "Numpad 8";
        public const string NUMPAD_9 = "Numpad 9";
        public const string D_0 = "0";
        public const string D_1 = "1";
        public const string D_2 = "2";
        public const string D_3 = "3";
        public const string D_4 = "4";
        public const string D_5 = "5";
        public const string D_6 = "6";
        public const string D_7 = "7";
        public const string D_8 = "8";
        public const string D_9 = "9";
        public const string ADD = "+";
        public const string MULTIPLY = "*";
        public const string MINUS = "-";
        public const string DECIMAL = ".";
        public const string DEVIDE = "/";
        public const string F1 = "F1";
        public const string F2 = "F2";
        public const string F3 = "F3";
        public const string F4 = "F4";
        public const string F5 = "F5";
        public const string F6 = "F6";
        public const string F7 = "F7";
        public const string F8 = "F8";
        public const string F9 = "F9";
        public const string F10 = "F10";
        public const string F11 = "F11";
        public const string F12 = "F12";
        public const string F13 = "F13";
        public const string F14 = "F14";
        public const string F15 = "F15";
        public const string F16 = "F16";
        public const string F17 = "F17";
        public const string F18 = "F18";
        public const string F19 = "F19";
        public const string F20 = "F20";
        public const string F21 = "F21";
        public const string F22 = "F22";
        public const string F23 = "F23";
        public const string BACKSPACE = "Backspace";
        public const string TAB = "Tab";
        public const string ENTER = "Enter";
        public const string LEFT_SHIFT = "LShift";
        public const string RIGHT_SHIFT = "RShift";
        public const string CONTROL = "Control";
        public const string L_CONTROL = "L Control";
        public const string R_CONTROL = "R Control";
        public const string ALT = "Alt";
        public const string LMENU = "LMenu(LAlt)";
        public const string KANAMODE = "KANAMODE(RAlt)";
        public const string KANJIMODE = "KANJIMODE(RCtrl)";
        public const string APPS = "Apps(ContextMenu)";
        public const string CAPS_LOCK = "Caps Lock";
        public const string ESC = "Esc";
        public const string SPACE = "Space";
        public const string PAGEUP = "PageUp";
        public const string PAGEDOWN = "PageDown";
        public const string END = "End";
        public const string HOME = "Home";
        public const string LEFT = "←";
        public const string RIGHT = "→";
        public const string UP = "↑";
        public const string DOWN = "↓";
        public const string INSERT = "Insert";
        public const string DELETE = "Delete";
        public const string NUMLOCK = "NumLock";
        public const string PRINTSCREEN = "PrintScreen";
        public const string SCROLL_LOCK = "Scroll Lock";
        public const string PAUSE_BREAK = "Pause Break";
        public const string MENU = "Menu";
        public const string MEDIANEXTTRACK = "MediaNextTrack";
        public const string MEDIAPLAYPAUSE = "MediaPlayPause";
        public const string MEDIAPREVIOUSTRACK = "MediaPreviousTrack";
        public const string MEDIASTOP = "MediaStop";
        public const string VOLUMEMUTE = "VolumeMute";
        public const string VOLUMEDOWN = "VolumeDown";
        public const string VOLUMEUP = "VolumeUp";
        public const string BROWSERBACK = "BrowserBack";
        public const string BROWSERFORWARD = "BrowserForward";
        public const string BROWSERREFRESH = "BrowserRefresh";
        public const string BROWSERSTOP = "BrowserStop";
        public const string BROWSERSEARCH = "BrowserSearch";
        public const string BROWSERFAVORITES = "BrowserFavorites";
        public const string BROWSERHOME = "BrowserHome";
        public const string LWIN = "LWin";
        public const string RWIN = "RWin";

        public string name { get; set; }
        public Keys key { get; set; }
        public IntPtr id { get; set; }
        public KeyInfo(string name, Keys key, nint? id = null) {
            this.name = name;
            this.key = key;

            if(id == null)
                this.id = (int)key;
            else
                this.id = (int)id;
        }
    }

    public class Variable {
        public int id { get; set; }
        public string name { get; set; }
        public bool value { get; set; }
        public Variable(int id, string name, bool value) {
            this.id = id;
            this.name = name;
            this.value = value;
        }

        public Variable(Variable v) {
            this.id = v.id;
            this.name = v.name;
            this.value = v.value;
        }

        public override string ToString() {
            return $"Variable : {name} (id:{id}, value:{value}, name:{name})";
        }
    }

    public enum ActivateCondition {
        ANY = 0,
        ON = 1,
        OFF = 2,
    }
}
