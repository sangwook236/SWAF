﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.CoreUnitTest.Log
{
    using SAF.Core.Log;
    using NUnit.Framework;

    [TestFixture]
    class Log4NetLogTest
    {
        [SetUp]
        public void setUp()
        {
        }

        [TearDown]
        public void tearDown()
        {
        }

        [Test]
        public void testDefaultLogger()
        {
            ILog logger = Log4NetLog.getDefaultLogger();
            Assert.IsNotNull(logger);
            logger.debug("(#1) it's a debug-level log message.");
            logger.info("(#1) it's a info-level log message.");
            logger.warn("(#1) it's a warn-level log message.");
            logger.error("(#1) it's a error-level log message.");
            logger.fatal("(#1) it's a fatal-level log message.");
        }

        [Test]
        public void testNullLogger()
        {
            ILog logger = Log4NetLog.getLogger(null);
            Console.WriteLine("{0}", logger.ToString());
            Assert.IsNotNull(logger);
            Assert.AreEqual(logger.ToString(), "SAF.Core.Log.Log4NetLog");
            logger.debug("(#2) it's a debug-level log message.");
            logger.info("(#2) it's a info-level log message.");
            logger.warn("(#2) it's a warn-level log message.");
            logger.error("(#2) it's a error-level log message.");
            logger.fatal("(#2) it's a fatal-level log message.");
        }

        [Test]
        public void testSAFClient1Logger()
        {
            string loggerName = "SAF_Client.Logger";
            ILog logger = Log4NetLog.getLogger(loggerName);
            Assert.IsNotNull(logger);
            logger.debug("(#3) it's a debug-level log message.");
            logger.info("(#3) it's a info-level log message.");
            logger.warn("(#3) it's a warn-level log message.");
            logger.error("(#3) it's a error-level log message.");
            logger.fatal("(#3) it's a fatal-level log message.");
        }

        [Test]
        public void testSAFClient2Logger()
        {
            string loggerName = "SAF_Client2.Logger";
            ILog logger = Log4NetLog.getLogger(loggerName);
            Assert.IsNotNull(logger);
            logger.debug("(#4) it's a debug-level log message.");
            logger.info("(#4) it's a info-level log message.");
            logger.warn("(#4) it's a warn-level log message.");
            logger.error("(#4) it's a error-level log message.");
            logger.fatal("(#4) it's a fatal-level log message.");
        }

        [Test]
        public void testSAFClient3Logger()
        {
            string loggerName = "SAF_Client3.Logger";
            ILog logger = Log4NetLog.getLogger(loggerName);
            Assert.IsNotNull(logger);
            logger.debug("(#5) it's a debug-level log message.");
            logger.info("(#5) it's a info-level log message.");
            logger.warn("(#5) it's a warn-level log message.");
            logger.error("(#5) it's a error-level log message.");
            logger.fatal("(#5) it's a fatal-level log message.");
        }

        [Test]
        public void testSAFClient4Logger()
        {
            string loggerName = "SAF_Client4.Logger";
            ILog logger = Log4NetLog.getLogger(loggerName);
            Assert.IsNotNull(logger);
            Assert.AreEqual(logger.ToString(), "SAF.Core.Log.Log4NetLog");
        }
    }
}
