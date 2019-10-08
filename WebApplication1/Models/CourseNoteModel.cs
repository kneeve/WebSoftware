using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class CourseNoteModel
    {
        public int CourseNoteID { get; set; }
        public string Note { get; set; }
        public int CourseInstanceID { get; set; }
        public CourseInstance Course { get; set; }
    }
}
