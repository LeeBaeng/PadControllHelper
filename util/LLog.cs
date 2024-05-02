using System.Diagnostics;
using System;

namespace UKW.Util.common {
    public class LLog {
        public enum LogLevel : int {
            VERBOSE = 0,
            DEBUG = 1,
            INFO = 2,
            WARN = 3,
            ERROR = 4,
            EXCEPT = 5,
            NONE = 6,
            SYSTEM = 7
        }

        private static List<ILLogListener> logListenerList = new List<ILLogListener>();

        private const string DEFAULT_HEADER = "LLog";

        /// <summary>
        /// 각 레벨에 표시될 헤더 string
        /// </summary>
        public static string[] LogLevelHeader = new string[] { " vbs  ", " dbg_ ", " Inf@ ", " Wan> ", " ERR> ", "!EXC! ", "", " SYS> " };

        /// <summary>
        /// 콘솔에 출력될 Log Level
        /// 설정한 값의 이하의 레벨 로그만 출력된다.
        /// </summary>
        public static LogLevel logLevel { get; set; } = LogLevel.VERBOSE;

        /// <summary>
        /// 로그 첫부분에 표시될 대표 태그. AppName 혹은 LLog 사용 권장
        /// </summary>
        public static string logHeader { get; set; } = DEFAULT_HEADER;

        /// <summary>
        /// Verbose 로그를 출력한다.(Log level : 0)
        /// </summary>
        /// <param name="log">출력할 문자</param>
        /// <param name="tag">태그</param>
        public static void verbose(string log, object tag = null) { Log(LogLevel.VERBOSE, log, tag); }

        /// <summary>
        /// Debug 로그를 출력한다.(Log level : 1)
        /// </summary>
        /// <param name="log">출력할 문자</param>
        /// <param name="tag">태그</param>
        public static void debug(string log, object tag = null) { Log(LogLevel.DEBUG, log, tag); }

        /// <summary>
        /// Info 로그를 출력한다.(Log level : 2)
        /// </summary>
        /// <param name="log">출력할 문자</param>
        /// <param name="tag">태그</param>
        public static void info(string log, object tag = null) { Log(LogLevel.INFO, log, tag); }

        /// <summary>
        /// Warning 로그를 출력한다.(Log level : 3)
        /// </summary>
        /// <param name="log">출력할 문자</param>
        /// <param name="tag">태그</param>
        public static void warn(string log, object tag = null) { Log(LogLevel.WARN, log, tag); }

        /// <summary>
        /// Error 로그를 출력한다.(Log level : 4)
        /// </summary>
        /// <param name="log">출력할 문자</param>
        /// <param name="tag">태그</param>
        public static void err(string log, object tag = null) { Log(LogLevel.ERROR, log, tag); }


        /// <summary>
        /// Exception 로그를 출력한다.(Log level : 5)
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="log">출력할 문자</param>
        /// <param name="tag">태그</param>
        public static void except(Exception e, string log, object tag = null) { Log(LogLevel.EXCEPT, log, tag, e); }



        /// <summary>
        /// System 로그를 출력한다.(Log level : 7)
        /// </summary>
        /// <param name="log">출력할 문자</param>
        /// <param name="tag">태그</param>
        /// <param name="printSpline">시스템 로그를 강조하기 위한 Spline을 함께 표시할 지 여부</param>
        public static void sys(string log, object tag = null, bool printSpline = true) {
            if(logLevel > LogLevel.SYSTEM)
                return;

            string[] splitStr = log.Split('\n');
            string header = getHeader(LogLevel.SYSTEM, tag);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;

            if(printSpline) {
                notifyLogToListener(LogLevel.SYSTEM, header + "┏━━━━━System━━━━━━━━━━━━━━━━━━━━━━", tag);
                if(splitStr != null && splitStr.Length > 0) {
                    for(int i = 0; i < splitStr.Length; i++)
                        notifyLogToListener(LogLevel.SYSTEM, header + "┃" + splitStr[i], tag);
                } else {
                    notifyLogToListener(LogLevel.SYSTEM, header + "┃" + log, tag);
                }
                notifyLogToListener(LogLevel.SYSTEM, header + "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", tag);
            } else {
                if(splitStr != null && splitStr.Length > 0) {
                    for(int i = 0; i < splitStr.Length; i++)
                        notifyLogToListener(LogLevel.SYSTEM, header + splitStr[i], tag);
                } else {
                    notifyLogToListener(LogLevel.SYSTEM, header + log, tag);
                }
            }
        }

        private static void Log(LogLevel level, string msg, object tag = null, Exception e = null) {
            // 출력 설정 값 보다 저수준 로그레벨 출력 무시
            if(logLevel > level)
                return;

            string[] splitStr = msg.Split('\n');
            string header = getHeader(level, tag);

            lock(Console.Out) {
                switch(level) {
                    case LogLevel.VERBOSE:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case LogLevel.DEBUG:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case LogLevel.INFO:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;

                    case LogLevel.WARN:
                        Console.ForegroundColor = ConsoleColor.Green;
                        header += "[[[ Warning ]]]==> ";
                        break;

                    case LogLevel.ERROR:
                        Console.ForegroundColor = ConsoleColor.Red;
                        notifyLogToListener(level, header + "┌─────Error ──────────────────────", tag);
                        notifyLogToListener(level, header + "│" + msg, tag);
                        notifyLogToListener(level, header + "└──────────────────────────────", tag);
                        return;

                    case LogLevel.EXCEPT:
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Red;

                        notifyLogToListener(level, "\n" + header + "┌─────Exception ────────────────────", tag);
                        if(splitStr != null && splitStr.Length > 0) {
                            for(int i = 0; i < splitStr.Length; i++)
                                notifyLogToListener(level, header + "│" + splitStr[i], tag);
                        } else {
                            notifyLogToListener(level, header + "│" + msg, tag);
                        }

                        notifyLogToListener(level, header + "│" + e, tag);
                        notifyLogToListener(level, header + "└────────────────────────────── \n", tag);
                        return;

                }
                if(splitStr != null && splitStr.Length > 0) {
                    for(int i = 0; i < splitStr.Length; i++) {
                        var str = header + splitStr[i];
                        notifyLogToListener(level, str, tag);
                    }
                } else {
                    var str = header + msg;
                    notifyLogToListener(level, str, tag);
                }
            }
        }

        private static string getHeader(LogLevel level, object tag = null) {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");
            var tagStr = "";
            if(tag != null)
                tagStr = "[" + tag.ToString() + "] ";
            return LogLevelHeader[(int)level] + time + tagStr + ": ";
        }

        /// <summary>
        /// Dictionary에 속한 아이템 리스트를 스트링으로 변환한다.
        /// </summary>
        public static string getDictionaryListString<K, V>(Dictionary<K, V> dict) {
            var str = "";
            foreach(KeyValuePair<K, V> entry in dict) {
                str = ("Key: " + entry.Key + ", Value: " + entry.Value + "\n");
            }
            return str;
        }

        private static void notifyLogToListener(LLog.LogLevel level, string log, object? tag = null) {
            Debug.WriteLine(log);
            logListenerList.ForEach(listener=> listener.onLog(level, log + Environment.NewLine, tag));
        }

        public static void addLogListener(ILLogListener listener) {
            logListenerList.Add(listener);
        }

        public static void removeLogListener(ILLogListener listener) {
            logListenerList.Remove(listener);
        }

        public static void clearLogListener() {
            logListenerList.Clear();
        }
    }


    /// <summary>
    /// 로그 출력을 위한 스트링 확장 메소드 (Extension Method) 
    /// </summary>
    static class LLogExtentionMethods {
        public static void logV(this string str, object tag = null) {
            LLog.verbose(str, tag);
        }
        public static void logD(this string str, object tag = null) {
            LLog.debug(str, tag);
        }
        public static void logI(this string str, object tag = null) {
            LLog.info(str, tag);
        }
        public static void logW(this string str, object tag = null) {
            LLog.warn(str, tag);
        }
        public static void logE(this string str, object tag = null) {
            LLog.err(str, tag);
        }
        public static void logEX(this Exception e, string log, object tag = null) {
            LLog.except(e, log, tag);
        }
        public static void logS(this string str, object tag = null) {
            LLog.sys(str, tag);
        }
        public static void logV<K, V>(this Dictionary<K,V> dict, object tag = null) {
            LLog.verbose(LLog.getDictionaryListString(dict), tag);
        }
        public static void logD<K, V>(this Dictionary<K, V> dict, object tag = null) {
            LLog.debug(LLog.getDictionaryListString(dict), tag);
        }
        public static void logI<K, V>(this Dictionary<K, V> dict, object tag = null) {
            LLog.info(LLog.getDictionaryListString(dict), tag);
        }
        public static void logW<K, V>(this Dictionary<K, V> dict, object tag = null) {
            LLog.warn(LLog.getDictionaryListString(dict), tag);
        }
        public static void logE<K, V>(this Dictionary<K, V> dict, object tag = null) {
            LLog.err(LLog.getDictionaryListString(dict), tag);
        }
        public static void logS<K, V>(this Dictionary<K, V> dict, object tag = null) {
            LLog.sys(LLog.getDictionaryListString(dict), tag);
        }
    }
}
