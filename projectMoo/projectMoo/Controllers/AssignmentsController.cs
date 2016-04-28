using projectMoo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMoo.Controllers
{
    public class AssignmentsController : Controller
    {
        private AssignmentsService _service = new AssignmentsService();

        // GET: Assignments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int ID)
        {
            var ViewModel = _service.GetAssignmentByID(ID);

            return View(ViewModel);
        }
    }
}