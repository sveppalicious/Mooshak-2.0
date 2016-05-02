using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMoo.Controllers
{
    public class CoursesController : Controller
    {

        [Authorize]
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
    }
}