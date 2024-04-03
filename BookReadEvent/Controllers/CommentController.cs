using BookReadEvent.Models;
using BookReadEvent.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepo commentrepo;

        public CommentController(ICommentRepo commentrepo)
        {
            this.commentrepo = commentrepo;
        }
        [Route("postcomment")]
        public IActionResult postcomment()
        {
            return View();
        }
        [Route("postcomment")]
        [HttpPost]

        public async Task<IActionResult> postcomment(Comment model)
        {
           var commentposted = await commentrepo.Postcomment(model);
            return RedirectToAction("Index", "Home");
        }
        
    }
}
