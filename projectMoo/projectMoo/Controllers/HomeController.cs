using Microsoft.AspNet.Identity;
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
            var model = _service.GetAssignmentForUser(User.Identity.GetUserId());
            if(model == null)
            {
                System.Diagnostics.Debug.WriteLine("Index model is null");
            }
            return View(model);
        }
    }
}