﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectMoo.Models.ViewModels
{
    public class AssignmentViewModel
    {
        public string Title { get; set; }
        public List<AssignmentMilestoneViewModel> Milestones { get; set; }
    }
}