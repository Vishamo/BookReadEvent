using BookReadEvent.Models;
using BookReadEvent.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly ICommentRepo commentRepo;

        public BookRepository(ApplicationDbContext applicationDbContext, ICommentRepo commentRepo)
        {
            this.applicationDbContext = applicationDbContext;
            this.commentRepo = commentRepo;
        }
        public int CreateEvent(EventModel model)
        {
            var newevent = new EventModel()
            {
                Title = model.Title,
                description = model.description,
                date = model.date,
                startTime = model.startTime,
                duration = model.duration,
                location = model.location,
                eventType = model.eventType,
                invite = model.invite,
                otherdetails = model.otherdetails,
                userId = model.userId
            };
            applicationDbContext.AddAsync(newevent);
            applicationDbContext.SaveChanges();
            return newevent.Id;
        }
        public async Task<List<EventModel>> viewEvent()
        {
            var dbevents = await applicationDbContext.Events.ToListAsync();
            foreach (var item in dbevents)
            {
                var comments = commentRepo.GetCommentsByEventId(item.Id);
                item.comments = comments;
            }

            return dbevents;
        }
        public async Task<EventModel> GetEventById(int id)
        {
            var detail = new EventModel();
            var data = await applicationDbContext.Events.ToListAsync();
            foreach (var item in data)
            {
                if (id == item.Id)
                {
                    detail.Id = id;
                    detail.Title = item.Title;
                    detail.location = item.location;
                    detail.date = item.date;
                    detail.description = item.description;
                    detail.duration = item.duration;
                    detail.eventType = item.eventType;
                    detail.comments = item.comments;
                    detail.invite = item.invite;
                    detail.startTime = item.startTime;
                    detail.otherdetails = item.otherdetails;
                    detail.userId = item.userId;
                }
            }
            return detail;
        }

        public IQueryable<EventModel> getupdateDetail(int id)
        {
            var updateevent = applicationDbContext.Events.Where(x => x.Id == id);
            return updateevent;
        }
        public void updateEvent(EventModel model)
        {
            var data = applicationDbContext.Events.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Title = model.Title;
                data.location = model.location;
                data.date = model.date;
                data.eventType = model.eventType;
                data.description = model.description;
                data.duration = model.duration;
                data.invite = model.invite;
                data.startTime = model.startTime;
                data.otherdetails = model.otherdetails;
                applicationDbContext.SaveChanges();
            }
        }

    }

}

