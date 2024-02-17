using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArijitDbContext _context;
        public HomeController(ILogger<HomeController> logger, ArijitDbContext _context)
        {
            _logger = logger;
            this._context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register ur)
        {
            if (ModelState.IsValid)
            {
                // Map values from hidden fields to corresponding properties in the model
                ur.TypeOfPerson = MapRegistrationType(ur.TypeOfPerson);
                ur.Gender = MapSex(ur.Gender);

                // Assuming you have a DbSet<Register> in your ArijitDbContext
                _context.Registers.Add(ur);
                _context.SaveChanges();

                // Redirect to a success page or another action
                return RedirectToAction("RegistrationSuccess");
            }
           
            return View(ur);
            // If ModelState is not valid, return to the registration view with errors

        }
        public IActionResult RegistrationSuccess()
        {
            // You can customize this action as needed, perhaps to display a success message or additional information.
            return View();
        }

        // Helper methods to map values
        private string MapRegistrationType(string mappedValue)
        {
            switch (mappedValue)
            {
                
                case "advocate":
                    return "A";
                case "in_person":
                    return "I";
                case "others":
                    return "O";
                default:
                    return null; // Handle default case or return appropriate default value
            }
        }

        private string MapSex(string mappedValue)
        {
            switch (mappedValue)
            {
                case "Male":
                    return "M";
                case "Female":
                    return "F";
                case "Others":
                    return "O";
                default:
                    return null; // Handle default case or return appropriate default value
            }
        }

        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
