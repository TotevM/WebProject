﻿using FitnessApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
	public class ProgressController : Controller
	{
		private readonly ILogger<ProgressController> logger;
		private readonly UserManager<ApplicationUser> user;

		public ProgressController(ILogger<ProgressController> _logger, UserManager<ApplicationUser> _user)
		{
			logger = _logger;
			user = _user;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
