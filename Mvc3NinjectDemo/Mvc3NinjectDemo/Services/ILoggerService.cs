using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc3NinjectDemo.Services
{
    public interface ILoggerService
    {
        string Name { get; set; }

        void Info(string message);
        void Info(string message, Dictionary<string, string> data);

        void Warn(string message);
        void Warn(string message, Dictionary<string, string> data);

        void Debug(string message);
        void Debug(string message, Dictionary<string, string> data);

        void Error(string message);
        void Error(string message, Exception exception);
        void Error(string message, Exception exception, Dictionary<string, string> data);

        void Fatal(string message);
        void Fatal(string message, Exception exception);
        void Fatal(string message, Exception exception, Dictionary<string, string> data);
    }

    public interface IStartUpTask
    {
        bool IsEnabled { get; }
        void Configure(string fileName);
    }
}