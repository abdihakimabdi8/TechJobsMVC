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
        public IActionResult Jobs(string column, string searchTerm)
        {
            if (column.Equals("all"))
            {
             
                List<Dictionary<string, string>> jobs = JobData.FindByValue( searchTerm);
                ViewBag.title = "All Jobs";
                ViewBag.searchTerm = searchTerm;
                ViewBag.jobs = jobs;
                return View("index");
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(column, searchTerm);
                ViewBag.title = "Jobs with " + ViewBag.columns[column] + ": " + searchTerm;
                ViewBag.jobs = jobs;

                return View();
            }
        }
    }
}
