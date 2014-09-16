using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Core.Log
{
    /**
     * @brief Log4Net library를 이용하는 logger.
     *
     * Logging을 위한 설정 파일은 현재 실행 파일이 존재하는 directory 하에 log/SAF_log_conf.xml에 존재하며,
     * 이 파일을 변경하여 각 logger의 logging 출력 형태 및 양식, 그리고 log level 등을 변경할 수 있다.
     *
     * 여기서 log level이란 log message와 관계된 수준을 말하며, 두 가지 목적을 위해 사용할 수 있다. <br>
     * 첫 번째는 각 log message가 가지는 수준을 의미하며, 각각의 logger가 log message를 기록할 때 지정하는 수준을 의미하며 아래의 값들을 가질 수 있다.
     * - Debug
     * - Info
     * - Warn
     * - Error
     * - Fatal
     *
     * 두 번째 의미는 logging 설정 파일에서 설정하는 값으로 각 log message의 출력여부를 결정하는 수준을 말하며 아래의 값들을 가질 수 있다.
     * - All
     * - Debug
     * - Info
     * - Warn
     * - Error
     * - Fatal
     * - Off
     *     
     * 각 log message에 지정된 수준(첫 번째 의미로서의 수준)과 logging 설정 파일에 지정된 출력 수준(두 번째 의미로서의 수준)에 따라 log message의 출력이 결정된다. <br>
     * 예를 들면, logging 설정 파일에 지정된 출력 수준이 Warn 수준인 경우,
     * 각 log message에 지정된 수준이 Warn 수준보다 높은, 즉 Warn / Error / Fatal 수준을 가지는 모든 log message는 지정된 logging channel을 통해 출력된다.
     *     
     * Log4NetLog 클래스의 사용 방법. <br>
     * 기본 logger를 이용해 log level이 warn인 상태로 message(여기서는 it's a warn-level log message.를 말함)를 출력한다.
     * @code
     * SAF.Core.Log.Log4NetLog.getDefaultLogger().Warn("it's a warn-level log message.");
     * @endcode
     * 
     * SAF_Client.Logger라는 이름을 가지는 logger를 이용해 log level이 error인 상태로 message(여기서는 it's an error-level log message.를 말함)를 출력한다.
     * @code
     * SAF.Core.Log.Log4NetLog.error("SAF_Client.Logger", "it's an error-level log message.");
     * @endcode
     */
    sealed public class Log4NetLog : ILog
    {
        /**
         * @brief Log4NetLog 객체를 설정하기 위한 static constructor.
         *
         * 실행 파일이 존재하는 directory 하에 log/SAF_log_conf.xml 파일이 존재하는 경우, 해당 파일로부터 설정을 로드한다.
         * 만약 해당 logging 설정 파일을 이용한 logger의 설정이 실패한다면, 기본 설정을 이용한다.
         */
        static Log4NetLog()
        {
            bool useBasicConfigurator = false;
            try
            {
                System.IO.FileInfo configFileInfo = new System.IO.FileInfo(".\\Log\\SAF_log_conf.xml");
                if (configFileInfo.Exists)
                    log4net.Config.XmlConfigurator.Configure(configFileInfo);
                else
                    useBasicConfigurator = true;
            }
            catch (Exception)
            {
                useBasicConfigurator = true;
            }

            if (useBasicConfigurator)
            {
                log4net.Layout.PatternLayout patternLayout = new log4net.Layout.PatternLayout();
                patternLayout.ConversionPattern = "%5p [%5t] %c{3} (%F:%L) %d{ISO8601} - %m%n";
                patternLayout.ActivateOptions();

                log4net.Appender.RollingFileAppender fileAppender = new log4net.Appender.RollingFileAppender();
                fileAppender.AppendToFile = true;
                fileAppender.MaximumFileSize = "1MB";
                fileAppender.MaxSizeRollBackups = 10;
                fileAppender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();
                fileAppender.File = ".\\log\\SAF_default_log.log";
                fileAppender.Layout = patternLayout;
                fileAppender.ActivateOptions();

                log4net.Config.BasicConfigurator.Configure(fileAppender);

                ILog log = new Log4NetLog();
                log.warn("Log4NetLog configuration error: default configurator will be used");
            }
        }

        /**
         * @brief 실행중인 Application 이름을 기초로 한 기본 logger를 반환.
         */
        public static ILog getDefaultLogger()
        {
            return new Log4NetLog();
        }

        /**
         * @brief 지정된 logger 이름을 가지는 logger를 반환.
         *
         * @param[in] loggerName log message 출력을 위해 사용할 logger 이름.
         */
        public static ILog getLogger(string loggerName)
        {
            return new Log4NetLog(loggerName);
        }

        /**
         * @brief 실행중인 Application 이름을 기초로 한 기본 logger를 생성.
         */
        private Log4NetLog()
        {
            string appPath = Environment.GetCommandLineArgs()[0];
            int idx = appPath.LastIndexOf('\\');
            string appFileName = appPath.Substring(idx + 1);

            idx = appFileName.LastIndexOf('.');
            string appName = appFileName.Substring(0, idx);
            string appFileExt = appFileName.Substring(idx + 1);

            idx = appName.LastIndexOf('.');
            if (appName.Substring(idx + 1).ToLower().CompareTo("vshost") == 0)
                appName = appName.Substring(0, idx);

            logger_ = string.IsNullOrEmpty(appName) ? log4net.LogManager.GetLogger(typeof(Log4NetLog)) : log4net.LogManager.GetLogger(appName + ".Logger");
        }

        /**
         * @brief 지정된 logger 이름을 가지는 logger를 생성.
         *
         * @param[in] loggerName log message 출력을 위해 사용할 logger 이름.
         */
        private Log4NetLog(string loggerName)
        {
            logger_ = string.IsNullOrEmpty(loggerName) ? log4net.LogManager.GetLogger(typeof(Log4NetLog)) : log4net.LogManager.GetLogger(loggerName);
        }

        /**
         * @brief Debug 수준에서 log message를 출력.
         *
         * @param[in] msg 출력할 log message.
         */
        public void debug(string msg)
        {
            if (null != logger_) logger_.Debug(msg);
        }

        /**
         * @brief Info 수준에서 log message를 출력.
         *
         * @param[in] msg 출력할 log message.
         */
        public void info(string msg)
        {
            if (null != logger_) logger_.Info(msg);
        }

        /**
         * @brief Warn 수준에서 log message를 출력.
         *
         * @param[in] msg 출력할 log message.
         */
        public void warn(string msg)
        {
            if (null != logger_) logger_.Warn(msg);
        }

        /**
         * @brief Error 수준에서 log message를 출력.
         *
         * @param[in] msg 출력할 log message.
         */
        public void error(string msg)
        {
            if (null != logger_) logger_.Error(msg);
        }

        /**
         * @brief Fatal 수준에서 log message를 출력.
         *
         * @param[in] msg 출력할 log message.
         */
        public void fatal(string msg)
        {
            if (null != logger_) logger_.Fatal(msg);
        }

        private log4net.ILog logger_;
    }
}
