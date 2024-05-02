using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UKW.Util.time {
    public class CountdownTimer {
        Thread thread;

        /// <summary>
        /// CountdownTimer를 생성한다.
        /// 액션은 UI Thread가 아니므로 UI 작업이 필요한 경우 반드시 Cross-Thread에 대한 처리를 Action 내부에 작성해야 한다
        /// </summary>
        /// <param name="callback">카운트다운 타이머가 완료되면 실행될 액션</param>
        /// <param name="countdownTime">카운트다운 시간(millisecond)</param>
        public CountdownTimer(Action callback, int countdownTime) {
            thread = new Thread(new ThreadStart(() => {
                try {
                    Thread.Sleep(countdownTime);
                    callback();
                } catch(ThreadInterruptedException ex) { }
            }));
        }

        public void start() {
            if(thread.ThreadState == ThreadState.Unstarted)
                thread.Start();
        }

        public async Task startAsync() {
            thread.Start();
        }

        public void stop() {
            if(thread.ThreadState == ThreadState.Running || thread.ThreadState == ThreadState.WaitSleepJoin) {
                thread.Interrupt();
            }
        }

        public static async Task startCountDown(int countdownTime, Action? callback = null) {
            await Task.Delay(countdownTime);
            if(callback != null)
                callback();
        }
    }
}
