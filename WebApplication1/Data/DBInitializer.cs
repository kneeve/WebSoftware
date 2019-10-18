/**
 * Author:    Kaelin Hoang
 * Partner:   None
 * Date:      9/27/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang - This work may not be copied for use in Academic Coursework.
 *
 * I, Kaelin Hoang, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Initializes the database with values if not created already
 */
using EFGetStarted.AspNetCore.NewDb.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebApplication1.Models;
/// <summary>
/// Kaelin Hoang
/// Initializes database with values if it doesn't already have values in it.
/// 
/// </summary>
namespace WebApplication1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CourseContext context)
        {
            context.Database.Migrate();

            // Look for any courses.
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }
            // Create courses
            var courses = new CourseInstance[]
            {
            new CourseInstance{Dept="CS",Number=4540,Semester="Spring",Year=2019,Description="Web Software Architexture",InstructorEmail="professor_jim@cs.utah.edu"},
            new CourseInstance{Dept="CS",Number=2420,Semester="Spring",Year=2020,Description="Data Structures and Algorithms",InstructorEmail="professor_jim@cs.utah.edu"},
            new CourseInstance{Dept="CS",Number=3500,Semester="Spring",Year=2019,Description="Software Practice",InstructorEmail="professor_jim@cs.utah.edu"},
            new CourseInstance{Dept="CS",Number=2100,Semester="Fall",Year=2019,Description="Discrete Structures",InstructorEmail="professor_mary@cs.utah.edu"},
            new CourseInstance{Dept="CS",Number=4400,Semester="Fall",Year=2019,Description="Computer Systems",InstructorEmail="professor_mary@cs.utah.edu"},
            new CourseInstance{Dept="CS",Number=3500,Semester="Fall",Year=2019,Description="Software Practice",InstructorEmail="professor_danny@cs.utah.edu"},
            };
            foreach (CourseInstance s in courses)
            {
                context.Courses.Add(s);
            }
            context.SaveChanges();

            // Get Course IDs for courses
            int ID4540 = courses[0].CourseInstanceID;
            int ID2420 = courses[1].CourseInstanceID;
            int ID3500 = courses[2].CourseInstanceID;
            int ID2100 = courses[3].CourseInstanceID;
            int ID4400 = courses[4].CourseInstanceID;
            int ID35002 = courses[5].CourseInstanceID;

            // Create learning outcomes
            var lo = new LearningOutcomes[]
            {
            new LearningOutcomes{Name="Logic",Description="use symbolic logic to model real-world situations by converting informal language statements to propositional and predicate logic expressions, as well as apply formal methods to propositions and predicates (such as computing normal forms and calculating validity)",CourseInstanceID=ID2100},
            new LearningOutcomes{Name="Relations",Description="analyze problems to determine underlying recurrence relations, as well as solve such relations by rephrasing as closed formulas",CourseInstanceID=ID2100},
            new LearningOutcomes{Name="Sets",Description="assign practical examples to the appropriate set, function, or relation model, while employing the associated terminology and operations",CourseInstanceID=ID2100},
            new LearningOutcomes{Name="Permutations",Description="map real-world applications to appropriate counting formalisms, including permutations and combinations of sets, as well as exercise the rules of combinatorics (such as sums, products, and inclusion-exclusion)",CourseInstanceID=ID2100},
            new LearningOutcomes{Name="Events",Description="calculate probabilities of independent and dependent events, in addition to expectations of random variables",CourseInstanceID=ID2100},
            new LearningOutcomes{Name="Data Structures",Description="implement, and analyze for efficiency, fundamental data structures (including lists, graphs, and trees) and algorithms (including searching, sorting, and hashing)",CourseInstanceID=ID2420},
            new LearningOutcomes{Name="BigO",Description="employ Big-O notation to describe and compare the asymptotic complexity of algorithms, as well as perform empirical studies to validate hypotheses about running time",CourseInstanceID=ID2420},
            new LearningOutcomes{Name="Abstract",Description="recognize and describe common applications of abstract data types (including stacks, queues, priority queues, sets, and maps)",CourseInstanceID=ID2420},
            new LearningOutcomes{Name="Real",Description="apply algorithmic solutions to real-world data",CourseInstanceID=ID2420},
            new LearningOutcomes{Name="Generics",Description="use generics to abstract over functions that differ only in their types",CourseInstanceID=ID2420},
            new LearningOutcomes{Name="Pairs",Description="appreciate the collaborative nature of computer science by discussing the benefits of pair programming",CourseInstanceID=ID2420},
            new LearningOutcomes{Name="Large Programs",Description="design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)",CourseInstanceID=ID3500},
            new LearningOutcomes{Name="Testing",Description="perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software",CourseInstanceID=ID3500},
            new LearningOutcomes{Name="MVC",Description="apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface",CourseInstanceID=ID3500},
            new LearningOutcomes{Name="CSM",Description="exercise the client-server model and high-level networking APIs to build a web-based software system",CourseInstanceID=ID3500},
            new LearningOutcomes{Name="DB",Description="operate a modern relational database to define relations, as well as store and retrieve data",CourseInstanceID=ID3500},
            new LearningOutcomes{Name="Peer",Description="appreciate the collaborative nature of software development by discussing the benefits of peer code reviews",CourseInstanceID=ID3500},
            new LearningOutcomes{Name="OS",Description="explain the objectives and functions of abstraction layers in modern computing systems, including operating systems, programming languages, compilers, and applications",CourseInstanceID=ID4400},
            new LearningOutcomes{Name="Mem",Description="understand cross-layer communications and how each layer of abstraction is implemented in the next layer of abstraction (such as how C programs are translated into assembly code and how C library allocators are implemented in terms of operating system memory management)",CourseInstanceID=ID4400},
            new LearningOutcomes{Name="Performance",Description="analyze how the performance characteristics of one layer of abstraction affect the layers above it (such as how caching and services of the operating system affect the performance of C programs)",CourseInstanceID=ID4400},
            new LearningOutcomes{Name="Os Concepts",Description="construct applications using operating-system concepts (such as processes, threads, signals, virtual memory, I/O)",CourseInstanceID=ID4400},
            new LearningOutcomes{Name="Applications",Description="synthesize operating-system and networking facilities to build concurrent, communicating applications",CourseInstanceID=ID4400},
            new LearningOutcomes{Name="Synchronization",Description="implement reliable concurrent and parallel programs using appropriate synchronization constructs",CourseInstanceID=ID4400},
            new LearningOutcomes{Name="HTML/CSS",Description="Construct web pages using modern HTML and CSS practices, including modern frameworks.",CourseInstanceID=ID4540},
            new LearningOutcomes{Name="Accessability",Description="Define accessibility and utilize techniques to create accessible web pages.",CourseInstanceID=ID4540},
            new LearningOutcomes{Name="MVC",Description="Outline and utilize MVC technologies across the “full-stack” of web design (including front-end, back-end, and databases) to create interesting web applications. Deploy an application to a “Cloud” provider.",CourseInstanceID=ID4540},
            new LearningOutcomes{Name="Security",Description="Describe the browser security model and HTTP; utilize techniques for data validation, secure session communication, cookies, single sign-on, and separate roles.  ",CourseInstanceID=ID4540},
            new LearningOutcomes{Name="JavaScript",Description="Utilize JavaScript for simple page manipulations and AJAX for more complex/complete “single-page” applications.",CourseInstanceID=ID4540},
            new LearningOutcomes{Name="Pages",Description="Demonstrate how responsive techniques can be used to construct applications that are usable at a variety of page sizes.  Define and discuss responsive, reactive, and adaptive.",CourseInstanceID=ID4540},
            new LearningOutcomes{Name="Web Crawler",Description="Construct a simple web-crawler for validation of page functionality and data scraping.",CourseInstanceID=ID4540},
            new LearningOutcomes{Name="Large Programs",Description="design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)",CourseInstanceID=ID35002},
            new LearningOutcomes{Name="Testing",Description="perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software",CourseInstanceID=ID35002},
            new LearningOutcomes{Name="MVC",Description="apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface",CourseInstanceID=ID35002},
            new LearningOutcomes{Name="CSM",Description="exercise the client-server model and high-level networking APIs to build a web-based software system",CourseInstanceID=ID35002},
            new LearningOutcomes{Name="DB",Description="operate a modern relational database to define relations, as well as store and retrieve data",CourseInstanceID=ID35002},
            new LearningOutcomes{Name="Peer",Description="appreciate the collaborative nature of software development by discussing the benefits of peer code reviews",CourseInstanceID=ID35002},
            };
            foreach (LearningOutcomes c in lo)
            {
                context.Descriptions.Add(c);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Created with tutorial from class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static async Task InitializeAsync(LearningOutcomesContext context, IServiceProvider serviceProvider)
        {
            context.Database.EnsureCreated();
            RoleManager<IdentityRole> rm = serviceProvider
               .GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Instructor", "Chair" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await rm.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await rm.CreateAsync(new IdentityRole(roleName));
                }
            }

            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            UserManager<IdentityUser> userManager = serviceProvider
               .GetRequiredService<UserManager<IdentityUser>>();

            // Initialize Erin as admin
            var erinUser = await userManager
               .FindByEmailAsync("admin_erin@cs.utah.edu");

            if (erinUser == null)
            {
                IdentityUser poweruser = new IdentityUser
                {
                    UserName = "admin_erin@cs.utah.edu",
                    Email = "admin_erin@cs.utah.edu"
                };
                string UserPassworde = "123ABC!@#def";
                var createPowerUsere = await userManager.CreateAsync(poweruser, UserPassworde);
                if (createPowerUsere.Succeeded)
                {
                    await userManager.AddToRoleAsync(poweruser, "Admin");
                }
            }

            // Initialize Jim as isntructor
            var JimUser = await userManager
               .FindByEmailAsync("professor_jim@cs.utah.edu");

            if (JimUser == null)
            {
                IdentityUser jimuser = new IdentityUser
                {
                    UserName = "professor_jim@cs.utah.edu",
                    Email = "professor_jim@cs.utah.edu"
                };
                string UserPasswordj = "123ABC!@#def";
                var createPowerUserj = await userManager.CreateAsync(jimuser, UserPasswordj);
                if (createPowerUserj.Succeeded)
                {
                    await userManager.AddToRoleAsync(jimuser, "Instructor");
                }
            }

            // Initialize Mary as instructor
            var MaryUser = await userManager
               .FindByEmailAsync("professor_mary@cs.utah.edu");

            if (MaryUser == null)
            {
                IdentityUser maryuser = new IdentityUser
                {
                    UserName = "professor_mary@cs.utah.edu",
                    Email = "professor_mary@cs.utah.edu"
                };
                string UserPasswordm = "123ABC!@#def";
                var createPowerUserm = await userManager.CreateAsync(maryuser, UserPasswordm);
                if (createPowerUserm.Succeeded)
                {
                    await userManager.AddToRoleAsync(maryuser, "Instructor");
                }
            }

            // Initialize Danny as instructor
            var DannyUser = await userManager
               .FindByEmailAsync("professor_danny@cs.utah.edu");

            if (DannyUser == null)
            {
                IdentityUser danuser = new IdentityUser
                {
                    UserName = "professor_danny@cs.utah.edu",
                    Email = "professor_danny@cs.utah.edu"
                };
                string UserPasswordd = "123ABC!@#def";
                var createPowerUserd = await userManager.CreateAsync(danuser, UserPasswordd);
                if (createPowerUserd.Succeeded)
                {
                    await userManager.AddToRoleAsync(danuser, "Instructor");
                }
            }

            // Initialize Whit as chair
            var whitUser = await userManager
               .FindByEmailAsync("chair_whitaker@cs.utah.edu");

            if (whitUser == null)
            {
                IdentityUser whituser = new IdentityUser
                {
                    UserName = "chair_whitaker@cs.utah.edu",
                    Email = "chair_whitaker@cs.utah.edu"
                };
                string UserPasswordw = "123ABC!@#def";
                var createPowerUserw = await userManager.CreateAsync(whituser, UserPasswordw);
                if (createPowerUserw.Succeeded)
                {
                    await userManager.AddToRoleAsync(whituser, "Chair");
                }
            }
        }
    }
}