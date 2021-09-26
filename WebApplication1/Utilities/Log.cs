using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using WebApplication1.Controllers;

namespace WebApplication1.Utilities
{
    public class Log
    {
        private static readonly Log _instance = new Log();
        protected ILog monitoringLogger;
        protected static ILog debugLogger;

        private Log()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }


        /// <summary>
        /// Format a message log with sender's information for display purposes
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        public string FormatDebugMessage(string message)
        {
            StackFrame stack = new StackFrame(2);

            if (stack == null) return message;

            var method = stack.GetMethod();

            if (method == null) return message;

        
            return System.String.Format(
                "{0} ({1} in {2})",
                message ?? String.Empty,
                method != null ? (method.Name ?? String.Empty) : String.Empty,
                method != null && method.ReflectedType != null ? (method.ReflectedType.FullName ?? String.Empty) : String.Empty
                );
        }

        /// <summary>
        /// Used to log Debug messages in an explicit Debug Logger
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Debug(string message)
        {
            debugLogger.Debug(_instance.FormatDebugMessage(message));
        }

       
        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Debug(string message, System.Exception exception)
        {
            debugLogger.Debug(_instance.FormatDebugMessage(message), exception);
        }

        
        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Info(string message)
        {
            _instance.monitoringLogger.Info(message);
        }

        
        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Info(string message, System.Exception exception)
        {
            _instance.monitoringLogger.Info(message, exception);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Warn(string message)
        {
            _instance.monitoringLogger.Warn(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Warn(string message, System.Exception exception)
        {
            _instance.monitoringLogger.Warn(message, exception);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Error(string message)
        {
            _instance.monitoringLogger.Error(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Error(string message, System.Exception exception)
        {
            _instance.monitoringLogger.Error(message, exception);
        }

        
        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Fatal(string message)
        {
            _instance.monitoringLogger.Fatal(message);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Fatal(string message, System.Exception exception)
        {
            _instance.monitoringLogger.Fatal(message, exception);
        }

        /// <summary>
        /// Shutdown log4net
        /// </summary>
        public static void ShutDown()
        {
            LogManager.Shutdown();
        }

        /// <summary>
        /// Add indentation
        /// </summary>
        public static void Indent()
        {
            log4net.NDC.Push("  ");
        }

        /// <summary>
        /// Remove indentation
        /// </summary>
        public static void Unindent()
        {
            log4net.NDC.Pop();
        }

        /// <summary>
        /// Get the Debug status of the logger
        /// </summary>
        public static bool IsDebugEnabled
        {
            get
            {
                return debugLogger.IsDebugEnabled;
            }
        }
    }
}