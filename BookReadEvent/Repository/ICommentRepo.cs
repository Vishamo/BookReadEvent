using BookReadEvent.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookReadEvent.Repository
{
    public interface ICommentRepo
    {
        List<Comment> GetComments();
        List<Comment> GetCommentsByEventId(int id);
        Task<int> Postcomment(Comment comment);
        bool isNewComment(int id);
    }
}