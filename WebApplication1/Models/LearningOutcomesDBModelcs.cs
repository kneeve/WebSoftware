/**
 * Author:    Kaelin Hoang
 * Partner:   None
 * Date:      9/13/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.
 *
 * I, Kaelin Hoang, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Creates the structure for the learning outcomes table in the database 
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
    /// Definition of Learning Outcomes database
    /// </summary>
    public class LearningOutcomes
    {
        public int LearningOutcomesID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseInstanceID { get; set; }

        public CourseInstance Course { get; set; }
    }
}
