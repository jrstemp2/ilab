using IdentityExample1.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Identity.Dapper.Entities;
using IdentityExample1.Models;
using Microsoft.Extensions.Configuration;

namespace IdentityExample1.Controllers
{
    public class TaskController : Controller
    {
        int result;

        private DAL dal;

        private readonly UserManager<DapperIdentityUser> _userManager;
        private readonly SignInManager<DapperIdentityUser> _signInManager;
        private readonly ILogger _logger;

        public TaskController(
            UserManager<DapperIdentityUser> userManager,
            SignInManager<DapperIdentityUser> signInManager,
            ILoggerFactory loggerFactory,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            dal = new DAL(config.GetConnectionString("DefaultConnection"));
        }
        public IActionResult Index()
        {
            ViewData["Name"] = User.Identity.Name;
            
            ViewData["UID"] = _userManager.GetUserId(User);

            

            if (ViewData["Name"] != null)
            {
                int uId = int.Parse(_userManager.GetUserId(User));
                IEnumerable<UserTask> utasks = dal.GetTasks(uId);
                ViewData["UTasks"] = utasks;
                return View();
            }
            else
            {
                return View();
            }
        }


        //Add Task Get
        public IActionResult AddForm()
        {
            ViewData["Name"] = User.Identity.Name;

            ViewData["UID"] = _userManager.GetUserId(User);
            return View(new UserTask());
        }
        //Add Task Post
        [HttpPost]
        public IActionResult AddTask(UserTask u)
        {
            ViewData["Name"] = User.Identity.Name;

            ViewData["UID"] = _userManager.GetUserId(User);
            u.UserId = int.Parse(_userManager.GetUserId(User));

            result = dal.AddTask(u);
            
            return RedirectToAction("Index", u);
        }

        //Edit Task Get
        //Edit Task Post

        //Mark Task Complete

        //Delete Task
        public IActionResult Delete(int id)
        {
            int result = dal.DeleteTaskById(id);
            return RedirectToAction("Index");
        }
    }
}