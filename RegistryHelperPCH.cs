using UKW.Util.winapp;

namespace PadControllHelper {
    public class RegistryHelperPCH : RegistryHelper {
        const string KEY_PCH = "pch";

        const string REG_NAME_OPT_AUTORUN = "opt_autoRun";
        const string REG_NAME_OPT_AUTOMACROON = "opt_autoMacroOn";
        const string REG_NAME_OPT_TRAYMODE = "opt_trayMode";
        const string REG_NAME_OPT_ALAWAYSTOP = "opt_alwaysTop";

        public RegistryHelperPCH() : base(KEY_PCH) {
            // 최초실행의 경우(레지스트리 없는 경우) 기본옵션 ON 설정 (윈도우 시작시 자동실행, 트레이모드)
            if(getValue(REG_NAME_OPT_AUTORUN) == null)
                setOpt_AutoRun(true);
            if(getValue(REG_NAME_OPT_TRAYMODE) == null) 
                setOpt_TrayMode(true);
            
        }

        public void setOpt_AutoRun(bool val) {
            putValue(REG_NAME_OPT_AUTORUN, val);
            string _startupRegPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            if(val) {
                using(var regKey = GetRegKey(_startupRegPath, true)) {
                    try {
                        // 키가 이미 등록돼 있지 않을때만 등록
                        if(regKey.GetValue(KEY_PCH) == null)
                            regKey.SetValue(KEY_PCH, Application.ExecutablePath);
                        regKey.Close();
                    } catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            } else {
                using(var regKey = GetRegKey(_startupRegPath, true)) {
                    try {
                        // 키가 이미 존재할때만 제거
                        if(regKey.GetValue(KEY_PCH) != null)
                            regKey.DeleteValue(KEY_PCH, false);

                        regKey.Close();
                    } catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
                
        }
        public void setOpt_AutoMacroOn(bool val) => putValue(REG_NAME_OPT_AUTOMACROON, val);
        public void setOpt_TrayMode(bool val) => putValue(REG_NAME_OPT_TRAYMODE, val);
        public void setOpt_AlwaysTop(bool val) => putValue(REG_NAME_OPT_ALAWAYSTOP, val);

        public bool getOpt_AutoRun() => getOpt(REG_NAME_OPT_AUTORUN);
        public bool getOpt_AutoMacroOn() => getOpt(REG_NAME_OPT_AUTOMACROON);
        public bool getOpt_TrayMode() => getOpt(REG_NAME_OPT_TRAYMODE);
        public bool getOpt_AlwaysTop() => getOpt(REG_NAME_OPT_ALAWAYSTOP);
        private bool getOpt(string regName) {
            var s = getValue(regName);
            if(Boolean.TryParse(s?.ToString(), out var v))
                return v;
            return false;
        }

        private Microsoft.Win32.RegistryKey GetRegKey(string regPath, bool writable) {
            return Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regPath, writable);
        }
    }
}
