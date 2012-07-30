using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Mvc3NinjectDemo.Services
{
    public class LoggerService: ILoggerService
    {
        protected ILog Logger;
        protected string _name;
        private bool _isDebugEnabled;

        public LoggerService()
            : this("LoggerService")
        {
        }

        public LoggerService(string name)
        {
            _name = name;
            Logger = LogManager.GetLogger(name);
            _isDebugEnabled = Logger.IsDebugEnabled;
        }

        public string Name
        {
            get { return _name; }

            set
            {
                _name = value;
                Logger = LogManager.GetLogger(_name);
            }
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }



        public void Info(string message, Dictionary<string, string> data)
        {
            foreach (var item in data)
            {
                MDC.Set(item.Key, item.Value);
            }

            Logger.Info(message);
        }

        public void Warn(string message)
        {
            Logger.Warn(message);
        }

        public void Warn(string message, Dictionary<string, string> data)
        {
            MdcSetter(data);
            Logger.Warn(message);
        }

        public void Debug(string message)
        {
            if (_isDebugEnabled)
            {
                Logger.Debug(message);
            }
        }

        public void Debug(string message, Dictionary<string, string> data)
        {
            MdcSetter(data);
            Logger.Debug(message);
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            Logger.Error(message, exception);
        }

        public void Error(string message, Exception exception, Dictionary<string, string> data)
        {
            MdcSetter(data);
            Logger.Error(message, exception);
        }

        public void Fatal(string message)
        {
            Logger.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            Logger.Error(message, exception);
        }

        public void Fatal(string message, Exception exception, Dictionary<string, string> data)
        {
            MdcSetter(data);
            Logger.Error(message, exception);
        }



        private void MdcSetter(Dictionary<string, string> data)
        {
            foreach (var item in data)
            {
                MDC.Set(item.Key, item.Value);
            }
        }
    }
    public class Log4NetStartUpTask : IStartUpTask
    {
        public bool IsEnabled { get { return true; } }

        public void Configure(string fileName)
        {
            log4net.Config.XmlConfigurator.Configure(
                new System.IO.FileInfo(
                    HttpContext.Current.Server.MapPath(fileName)));
        }
    }
}