using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using mpwx.Data;

namespace mpwx.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IHostingEnvironment hostingEnv;
        protected readonly EntityModel db = null;

        public BaseController(IHostingEnvironment hostingEnvironment, EntityModel dbcontext)
        {
            hostingEnv = hostingEnvironment;
            db = dbcontext;
        }
    }
}
