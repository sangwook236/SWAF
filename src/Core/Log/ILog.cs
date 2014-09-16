using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.Core.Log
{
    public interface ILog
    {
        /**
         *  @brief Debug 수준에서 log message를 출력.
         *
         *  @param[in] msg 출력할 log message.
         */
        void debug(string msg);

        /**
         *  @brief Info 수준에서 log message를 출력.
         *
         *  @param[in] msg 출력할 log message.
         */
        void info(string msg);

        /**
         *  @brief Warn 수준에서 log message를 출력.
         *
         *  @param[in] msg 출력할 log message.
         */
        void warn(string msg);

        /**
         *  @brief Error 수준에서 log message를 출력.
         *
         *  @param[in] msg 출력할 log message.
         */
        void error(string msg);

        /**
         *  @brief Fatal 수준에서 log message를 출력.
         *
         *  @param[in] msg 출력할 log message.
         */
        void fatal(string msg);
    }
}
