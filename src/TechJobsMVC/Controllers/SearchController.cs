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
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            if (searchType.Equals("all"))

            {
                ViewBag.columns = ListController.columnChoices;
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "All Jobs";
                ViewBag.searchTerm = ViewBag.searchTerm;
                ViewBag.jobs = jobs;
            
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ViewBag.columns[searchType] + ": " + searchTerm;
                ViewBag.column = ViewBag.column;
                ViewBag.searchTerm = ViewBag.searchTerm;
                ViewBag.jobs = jobs;

                
            }
            return View("Index");
        }
    }
}
