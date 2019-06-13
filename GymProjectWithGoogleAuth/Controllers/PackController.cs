using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class PackController : Controller
    {
        // GET: Pack
        public ActionResult Index()
        {
            return View();
        }
    }
}