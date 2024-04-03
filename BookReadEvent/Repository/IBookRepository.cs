using BookReadEvent.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Repository
{
    public interface IBookRepository
    {
        int CreateEvent(EventModel model);
        Task<EventModel> GetEventById(int id);
        IQueryable<EventModel> getupdateDetail(int id);
        void updateEvent(EventModel model);
        Task<List<EventModel>> viewEvent();
    }
}