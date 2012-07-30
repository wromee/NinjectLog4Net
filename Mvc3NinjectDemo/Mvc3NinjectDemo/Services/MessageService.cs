using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc3NinjectDemo.Services
{
    public class MessageService: IMessageService
    {
        public string GetMessage()
        {
            return "Hello Ninject";
        }
    }
}