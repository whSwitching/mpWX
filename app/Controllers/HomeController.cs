using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mpwx.Models;
using mpwx.Data;
using Microsoft.AspNetCore.Hosting;

namespace mpwx.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHostingEnvironment hostingEnvironment, EntityModel dbcontext) : base(hostingEnvironment, dbcontext)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        public IActionResult Install()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
