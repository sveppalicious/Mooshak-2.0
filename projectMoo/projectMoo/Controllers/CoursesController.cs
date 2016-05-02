using projectMoo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMoo.Controllers
{
    public class CoursesController : Controller
    {

        private CoursesService _service = new CoursesService();

        [Authorize]
        // GET: Courses
        public ActionResult Index()
        {
            string currentUserId = "b6f3b153-68f3-4707-84f9-9d51e6d83d86";
            System.Diagnostics.Debug.WriteLine("user id " + currentUserId);
            var ViewModel = _service.getCoursesForUser(currentUserId);
            return View(ViewModel);
        }
    }
}