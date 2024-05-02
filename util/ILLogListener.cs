using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKW.Util.common {

    /// <summary>
    /// LLog 메세지 출력 리스너. 로그가 출력되는 경우 Listener에게 해당 로그를 알려준다.
    /// OSL(On Screen Log 등 구현시에 사용.)
    /// </summary>
    public interface ILLogListener {

        /// <summary>
        /// 로그 출력
        /// </summary>
        /// <param name="level">로그 레벨</param>
        /// <param name="log">header + msg 풀로그. line 출력의 경우 캐리지리턴이 포함됨.(또한 tag가 header로 변환되어 함께 출력 됨)</param>
        /// <param name="tag">태그 값만 별도로 전송. 태그가 없는 경우 null 전송. 일반적으로 log안에 header로 변환되어 함께 출력된다. 하지만 tag에 따른 별도 기능 구현이 필요한 경우에 사용</param>
        public void onLog(LLog.LogLevel level, string log, object? tag);
    }
}
