using Business.Abstract;
using DataAccess.Concrete;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using PaymentMvc.Models;
using System.Diagnostics;

namespace PaymentMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger/*, IAccountService accountService*/, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        //public IActionResult Index()
        //{
        //    //var result = _accountService.GetAll();
        //    //if (result!=null)
        //    //{
        //    //    return Ok(result);
        //    //}
        //    //return BadRequest(result);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}