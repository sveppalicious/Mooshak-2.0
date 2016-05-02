using projectMoo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMoo.Controllers
{
    public class HomeController : Controller
    {
        private AssignmentsService _service = new AssignmentsService();

        [Authorize]
        public ActionResult Index()
        {
            var model = _service.GetAssignmentByID(1);
            System.Diagnostics.Debug.WriteLine("The index");
            System.Diagnostics.Debug.WriteLine(model.Title);

            return View();
        }
    }
}