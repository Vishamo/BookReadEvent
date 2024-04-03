using BookReadEvent.Models;
using BookReadEvent.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository bookrepo;
        private readonly ICommentRepo commentRepo;

        public HomeController(IBookRepository bookrepo,ICommentRepo commentRepo)
        {
            this.bookrepo = bookrepo;
            this.commentRepo = commentRepo;
        }

        public async Task<ViewResult> Index()
        {
           var result=await bookrepo.viewEvent();
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
