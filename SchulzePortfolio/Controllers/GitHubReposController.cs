﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchulzePortfolio.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KSchulzePortfolio.Controllers
{
    public class GitHubReposController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //var allRepos = GitRepo.GetGitRepos();
            //return View(allRepos);
            return View();
        }
    }
}