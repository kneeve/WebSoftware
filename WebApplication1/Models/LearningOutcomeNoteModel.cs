using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class LearningOutcomeNoteModel
    {
        public int LearningOutcomeNoteID { get; set; }
        public string Note { get; set; }
        public int LearningOutcomesID { get; set; }
        public LearningOutcomes LearningOutcome { get; set; }
    }
}
