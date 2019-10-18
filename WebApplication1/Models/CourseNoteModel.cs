/**
 * Author:    Kaelin Hoang
 * Partner:   Khanhly Nguyen
 * Date:      10/18/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.
 *
 * I, Kaelin Hoang, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Course note model class 
 */
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
