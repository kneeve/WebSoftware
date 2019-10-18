/**
 * Author:    Kaelin Hoang
 * Partner:   Khanhly Nguyen
 * Date:      9/13/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.
 *
 * I, Kaelin Hoang, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Sets up the structure for the Course Instance table in the database
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Kaelin Hoang | u0984462
/// </summary>
namespace EFGetStarted.AspNetCore.NewDb.Models
{
    /// <summary>
    /// Initializes the Course Instance database attributes.
    /// </summary>
    public class CourseInstance
    {
        public int CourseInstanceID { get; set; }
        public string Dept { get; set; }
        public int Number { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string InstructorEmail { get; set; }
        public CourseNoteModel Note { get; set; }
        public virtual ICollection<LearningOutcomes> LOs { get; set; }
    }
}
