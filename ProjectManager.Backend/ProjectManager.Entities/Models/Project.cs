using System;
using System.Collections.Generic;

namespace ProjectManager.Entities.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public double PercentComplete { get; set; }
        public bool Late { get; set; }

        public virtual ICollection<Activity> Activities  {get; set; }
    }
}