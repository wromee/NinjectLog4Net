using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc3NinjectDemo.Services;

namespace Mvc3NinjectDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ILoggerService _loggerService;

        public HomeController(IMessageService messageService, ILoggerService loggerService)
        {
            _messageService = messageService;
            _loggerService = loggerService;
        }
        public ActionResult Index()
        {
            _loggerService.Debug(_messageService.GetMessage());
            ViewBag.Message = _messageService.GetMessage();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
