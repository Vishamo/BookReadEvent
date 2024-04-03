using BookReadEvent.Models;
using BookReadEvent.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookReadEvent.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ICommentRepo commentRepo;
       
        public BookController(IBookRepository bookRepository,ICommentRepo commentRepo)
        {
            this.bookRepository = bookRepository;
            this.commentRepo = commentRepo;
        
        }
       
    [Route("Create")]
    [Authorize]
        public IActionResult createevent()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult createevent(EventModel model)
        {
            if (ModelState.IsValid)
            {
                var result=bookRepository.CreateEvent(model);
                if(result.Equals(null))
                {
                    ModelState.AddModelError("", "Something Happend in Adding Event");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [Route("getevent")]
        [Authorize]
        public async Task<ViewResult> getevent()
        {
            var data=await bookRepository.viewEvent();
            return View(data);
        }

        public async  Task<ViewResult> eventdetail(int id)
        {
            var data = await bookRepository.GetEventById(id);
            List<Comment> comment=commentRepo.GetCommentsByEventId(id);
            data.comments = comment;
            return View(data);
        }
        [Authorize]
        public async  Task<ViewResult> eventDetailByMyEvent(int id)
        {
           var res= commentRepo.isNewComment(id);
            var data = await bookRepository.GetEventById(id);
            List<Comment> comment=commentRepo.GetCommentsByEventId(id);
            data.comments = comment;
            return View(data);
        }
        [Route("myevent")]
        [Authorize]
        public async Task<ViewResult> MyEvent()
        {
            var data = await bookRepository.viewEvent();
            return View(data);
        }

        [Authorize]
        public ViewResult UpdateEvent(int id)
        {
            var data = bookRepository.getupdateDetail(id);
                EventModel model = new EventModel();
                foreach (var item in data)
                {
                model.Title = item.Title;
                model.date = item.date;
                model.description = item.description;
                model.duration = item.duration;
                model.eventType = item.eventType;
                model.invite = item.invite;
                model.otherdetails = item.otherdetails;
                model.startTime = item.startTime;
                model.userId = item.userId;
                model.Id = item.Id;
                model.location = item.location;
                }
            
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateEvent(EventModel model)
        {
            if (ModelState.IsValid)
            {
                bookRepository.updateEvent(model);
                
            }
            return RedirectToAction("MyEvent", "Book");
        }
        [Authorize]
        public async Task<ViewResult> Invitations()
        {
            var data = await bookRepository.viewEvent();
            return View(data);
        }
    }
}
