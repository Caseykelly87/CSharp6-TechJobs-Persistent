using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;
using System.ComponentModel.DataAnnotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class JobController : Controller
    {
        private JobDbContext context;

        public JobController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("Job/Add")]
        public IActionResult Add()
        {
            List<Employer> employers = context.Employers.ToList();   
            AddJobViewModel addJobViewModel = new AddJobViewModel(employers);
            return View(addJobViewModel);
        }

        [HttpPost("Job/Add")]
        public IActionResult Add(AddJobViewModel addJobViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", addJobViewModel);
            }

                Job job = new() { Name = addJobViewModel.Name, EmployerId = addJobViewModel.EmployerId };
                context.Jobs.Add(job);
                context.SaveChanges();
                return Redirect("index");

        }

        public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();

            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).Single(j => j.Id == id);

            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

            return View(jobDetailViewModel);

        }
    }
}

