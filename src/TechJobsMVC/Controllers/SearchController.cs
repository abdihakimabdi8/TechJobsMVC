using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }
        
        [HttpPost]

        [Route("/Search")]
        public IActionResult Results(string column, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            if (column.Equals("all"))

            {
             
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
            
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(column, searchTerm);
                ViewBag.title = "Jobs with " + ViewBag.columns[column] + ": " + searchTerm;
                ViewBag.jobs = jobs;

                
            }
            return View("Index");
        }
    }
}
