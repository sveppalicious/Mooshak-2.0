using projectMoo.Models;
using projectMoo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectMoo.Services
{
    public class AssignmentsService
    {
        private ApplicationDbContext _db;

        public AssignmentsService()
        {
            _db = new ApplicationDbContext();
        }

        public List<AssignmentViewModel> GetAssignmentsInCourse(int CourseID)
        {
            // TODO:
            return null;
        }

        public AssignmentViewModel GetAssignmentByID(int AssignmentID)
        {
            var Assignment = _db.Assignments.SingleOrDefault(x => x.ID == AssignmentID);

            if (Assignment == null)
            {
                // Error
            }

            var milestones = _db.Milestones
                .Where(x => x.AssignmentID == AssignmentID)
                .Select(x => new AssignmentMilestoneViewModel
                {
                    Title = x.Title
                })
                .ToList();

            var viewModel = new AssignmentViewModel
            {
                Title = Assignment.Title,
                Milestones = milestones
            };

            return viewModel;
        }
    }
}