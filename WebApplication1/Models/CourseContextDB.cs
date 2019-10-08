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
 *    Creates the sets for Courses and learning outcomes for storage and queries. 
 */
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Kaelin Hoang
/// The purpose of this file is to set up the model to create the databases for the webpage.
/// </summary>
namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        { }

        public DbSet<CourseInstance> Courses { get; set; }
        public DbSet<CourseNoteModel> CourseNotes { get; set; }

        /// <summary>
        /// Descriptions = Learning Outcomes because while recreating the databases, the name was copy and pasted over
        /// from a previous solution and never got changed before rescaffolding.
        /// </summary>
        public DbSet<LearningOutcomes> Descriptions { get; set; } 
        public DbSet<LearningOutcomeNoteModel> LearningOutcomeNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseInstance>()
            .HasKey(c => c.CourseInstanceID);
            modelBuilder.Entity<LearningOutcomes>()
                .HasKey(c => c.LearningOutcomesID);
            modelBuilder.Entity<CourseNoteModel>().HasKey(c => c.CourseNoteID);
            modelBuilder.Entity<LearningOutcomeNoteModel>().HasKey(c => c.LearningOutcomeNoteID);
            modelBuilder.Entity<CourseInstance>().ToTable("Courses");
            modelBuilder.Entity<LearningOutcomes>().ToTable("LearningOutcomes");
        }
    }
}

