using projectMoo.Models;
using projectMoo.Models.Entities;
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
            var Assignments = (from assignment in _db.Assignments
                              where assignment.CourseID == CourseID
                              select assignment).ToList();



            if (Assignments == null)
            {
                System.Diagnostics.Debug.WriteLine("No assignment with that course ID found");
            }

            List<AssignmentViewModel> listAssignments = new List<AssignmentViewModel>();
            List<AssignmentMilestoneViewModel> listMilestones = new List<AssignmentMilestoneViewModel>();

            listMilestones.Add(new AssignmentMilestoneViewModel
            {
                Title = "fokk off",
                Description = "shut up",
                Grade = 0,
                Percentage = 100
            });
            
            foreach (var assign in Assignments)
            {
                listAssignments.Add(new AssignmentViewModel
                {
                    Title = assign.Title,
                    Description = assign.Description,
                    Milestones = listMilestones
                });
            }

            return listAssignments;
        }

        public AssignmentViewModel GetAssignmentByID(int AssignmentID)
        {
            var Assignment = _db.Assignments.SingleOrDefault(x => x.ID == AssignmentID);

            if (Assignment == null)
            {
                System.Diagnostics.Debug.WriteLine("No assignment with that ID found");
            }
            /*
            var milestones = _db.AssignmentMilestones
                .Where(x => x.AssignmentID == AssignmentID)
                .Select(x => new AssignmentMilestoneViewModel
                {
                    Title = x.Title,
                    Description = x.Description,
                    Grade = x.Grade,
                    Percentage = x.Percentage
                })
                .ToList();
            */
            var viewModel = new AssignmentViewModel
            {
                Title = Assignment.Title,
                //Milestones = milestones
            };
            
            return viewModel;
        }
    }
}