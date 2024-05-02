using PadControlHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PadControllHelper {

    public class CboItems {
        public Dictionary<string, CboActionItem> cboActionItems = new Dictionary<string, CboActionItem>();
        public Dictionary<string, CboShortcutItem> cboShortcutItems = new Dictionary<string, CboShortcutItem>();
        public Dictionary<string, CboVariableItem> cboVarItems = new Dictionary<string, CboVariableItem>();
        public Dictionary<string, CboActivateCondition> cboActivateCondition = new Dictionary<string, CboActivateCondition>();

        public CboItems() {
            cboActionItems.Add(CboActionItem.CLICK, new CboActionItem(CboActionItem.CLICK));
            cboActionItems.Add(CboActionItem.RIGHT_CLICK, new CboActionItem(CboActionItem.RIGHT_CLICK));
            cboActionItems.Add(CboActionItem.L_DOUBLE_CLICK, new CboActionItem(CboActionItem.L_DOUBLE_CLICK));
            cboActionItems.Add(CboActionItem.R_DOUBLE_CLICK, new CboActionItem(CboActionItem.R_DOUBLE_CLICK));
            cboActionItems.Add(CboActionItem.M_CLICK, new CboActionItem(CboActionItem.M_CLICK));
            cboActionItems.Add(CboActionItem.M_DOUBLE_CLICK, new CboActionItem(CboActionItem.M_DOUBLE_CLICK));
            cboActionItems.Add(CboActionItem.WHEEL_UP, new CboActionItem(CboActionItem.WHEEL_UP));
            cboActionItems.Add(CboActionItem.WHEEL_DOWN, new CboActionItem(CboActionItem.WHEEL_DOWN));

            foreach(KeyValuePair<string, KeyInfo> kv in KeyList.keyList)
                cboShortcutItems.Add(kv.Value.name, new CboShortcutItem(kv.Value));

            cboVarItems.Add(CboVariableItem.NOTUSE, new CboVariableItem(CboVariableItem.NOTUSE));
            //cboVarItems.Add(CboVariableItem.ADDNEW, new CboVariableItem(CboVariableItem.ADDNEW));

            cboActivateCondition.Add(CboActivateCondition.ANY, new CboActivateCondition(CboActivateCondition.ANY));
            cboActivateCondition.Add(CboActivateCondition.ON, new CboActivateCondition(CboActivateCondition.ON));
            cboActivateCondition.Add(CboActivateCondition.OFF, new CboActivateCondition(CboActivateCondition.OFF));
        }
    }

    public class CboItemBase {
        public string name { get; set; }

        public CboItemBase(string name) {
            this.name = name;
        }

        public override string ToString() {
            return name;
        }
    }

    public class CboActionItem : CboItemBase {
        public const string CLICK = "Click";
        public const string RIGHT_CLICK = "Right Click";
        public const string L_DOUBLE_CLICK = "L-Double Click";
        public const string R_DOUBLE_CLICK = "R-Double Click";
        public const string M_CLICK = "Middle Click";
        public const string M_DOUBLE_CLICK = "M-Double Click";
        public const string WHEEL_UP = "Wheel Up";
        public const string WHEEL_DOWN = "Wheel Down";

        public MacroAction action { get; set; }

        public CboActionItem(string name) : base(name) {
            switch(name) {
                case CLICK:
                    action = MacroAction.CLICK;
                    break;
                case RIGHT_CLICK:
                    action = MacroAction.RIGHT_CLICK;
                    break;
                case L_DOUBLE_CLICK:
                    action = MacroAction.L_DOUBLE_CLICK;
                    break;
                case R_DOUBLE_CLICK:
                    action = MacroAction.R_DOUBLE_CLICK;
                    break;
                case M_CLICK:
                    action = MacroAction.M_CLICK;
                    break;
                case M_DOUBLE_CLICK:
                    action = MacroAction.M_DOUBLE_CLICK;
                    break;
                case WHEEL_UP:
                    action = MacroAction.WHEEL_UP;
                    break;
                case WHEEL_DOWN:
                    action = MacroAction.WHEEL_DOWN;
                    break;
                default:
                    action = MacroAction.CLICK;
                    break;
            }
        }
    }

    public class CboVariableItem : CboItemBase {
        public const string NOTUSE = "-미사용-";
        public const string ADDNEW = "-신규추가-";

        public CboVariableItem(string name) : base(name) {}
    }

    public class CboShortcutItem : CboItemBase {
        public KeyInfo keyInfo { get; set; }

        public CboShortcutItem(KeyInfo keyCode) : base(keyCode.name) {
            this.keyInfo = keyCode;
        }
    }

    public class CboActivateCondition : CboItemBase {
        public const string ANY = "any";
        public const string ON = "on";
        public const string OFF = "off";

        public ActivateCondition activateCondition { get; set; }
        public CboActivateCondition(string name) : base(name) {
            switch(name) {
                case ANY:
                    activateCondition = ActivateCondition.ANY;
                    break;
                case ON:
                    activateCondition = ActivateCondition.ON;
                    break;
                case OFF:
                    activateCondition = ActivateCondition.OFF;
                    break;
            }
        }
    }
}
