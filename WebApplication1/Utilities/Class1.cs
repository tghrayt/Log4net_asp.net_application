using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace WebApplication1.Utilities
{
    public class Logger
    {
        private static object syncRoot = new Object();
        private static Logger instance = null;

        protected static ILog debugLogger = null;


        // private constructor
        private Logger()
        {
        }
        /// <summary>
        /// Gets an instance with default parameters based upon the caller
        /// </summary>
        /// <returns></returns>
        public static Logger GetInstance<T>(T t)
        {
            // make sure you return single instance
            if (debugLogger == null)
            {
                lock (syncRoot)
                {
                    debugLogger = LogManager.GetLogger(t.GetType());

                }
            }
            return instance;
        }
    }

}