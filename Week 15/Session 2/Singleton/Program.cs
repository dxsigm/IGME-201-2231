using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public interface ILogger
    {
        void OpenLogFile(string logFileName);
        void WriteToLog(string logInfo);
    }


    // eager loading singleton
    public class LoggingClass : ILogger
    {
        private static LoggingClass instance = new LoggingClass();

        public static LoggingClass GetInstance()
        {
            return instance;
        }

        private LoggingClass()
        {

        }

        public void OpenLogFile(string logFileName)
        {

        }

        public void WriteToLog(string logInfo)
        {

        }
    }


    // lazy loading Singleton
    public class BossCreature
    {

        private static BossCreature instance;

        // constructor
        private BossCreature() { }

        public static BossCreature Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BossCreature();
                }

                return instance;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LoggingClass logger = LoggingClass.GetInstance();

            ILogger iLogger = logger;

            iLogger.OpenLogFile("c:/log.txt");
            iLogger.WriteToLog("we're here");

            DoSomethingCool(iLogger);

            BossCreature bossCreature = BossCreature.Instance;


        }

        static void DoSomethingCool(ILogger logger)
        {
            logger.OpenLogFile("c:/log.txt");
            logger.WriteToLog("we're here");

        }
    }
}
