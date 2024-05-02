using Microsoft.Win32;
using System;

namespace UKW.Util.winapp {
    public class RegistryHelper {
        public string REG_KEY = "";

        RegistryKey regKey;

        /// <summary>
        /// RegistryHelper 인스턴스 생성
        /// RegistryHelper는 기본경로를 Software 하위로 지정된다.
        /// </summary>
        /// <param name="key">Software 하위에 생성할 Registry의 Key값</param>
        public RegistryHelper(string key) {
            this.REG_KEY = key;
            regKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey(key, true);
            if(regKey == null) {
                Registry.CurrentUser.CreateSubKey("Software").CreateSubKey(key);
                regKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey(key, true);
            }
        }

        /// <summary>
        /// 레지스트리에 값을 입력한다.
        /// </summary>
        /// <param name="name">입력할 필드의 name</param>
        /// <param name="value">입력될 값</param>
        /// <param name="valueKind">value의 타입</param>
        public void putValue<T>(string name, T value, RegistryValueKind valueKind = RegistryValueKind.String) {
            regKey.SetValue(name, value, valueKind);
        }

        /// <summary>
        /// 레지스트리에서 값을 읽어 반환한다.
        /// 데이터타입은 string으로만 반환된다.
        /// 값이 존재하지 않는 경우 null이 반환된다.
        /// </summary>
        /// <param name="name">읽어올 필드의 name</param>
        /// <returns></returns>
        public string? getValue(string name) {
            return regKey.GetValue(name)?.ToString();
        }
    }
}
