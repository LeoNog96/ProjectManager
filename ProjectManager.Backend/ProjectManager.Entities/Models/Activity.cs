using System;

namespace ProjectManager.Entities.Models
{
    public class Activity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool? Running { get; set; }
        public bool? Finished { get; set; }
        public long ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}