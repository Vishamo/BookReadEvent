using BookReadEvent.Models;
using BookReadEvent.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Repository
{
    public class CommentRepo : ICommentRepo
    {
        private readonly ApplicationDbContext appcontext;

        public CommentRepo(ApplicationDbContext appcontext)
        {
            this.appcontext = appcontext;
        }
        public async Task<int> Postcomment(Comment comment)
        {
            var newcomment = new Comment() { comment = comment.comment, Eventid = comment.Eventid, newcomment = true };
            await appcontext.AddAsync(newcomment);
            await appcontext.SaveChangesAsync();
            return comment.Id;
        }
        public List<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();
            var data = appcontext.comments.ToList();
            return data;
        }
        public List<Comment> GetCommentsByEventId(int id)
        {
            var data = GetComments();
            List<Comment> comments = new List<Comment>();
            if (data.Count != 0)
            {
                Comment idComment;
                foreach (var item in data)
                {
                    if (item.Eventid == id)
                    {   
                        idComment = new Comment();
                        idComment.comment = item.comment;
                        idComment.Eventid = id;
                        idComment.timestamp = item.timestamp;
                        idComment.Id = item.Id;
                        idComment.newcomment = item.newcomment;
                        comments.Add(idComment);
                    }
                }
            }
            return comments;
        }
        public bool isNewComment(int id)
        {
            bool use=false;
            var value = appcontext.comments.Where(x => x.Eventid == id);
            if(value!=null)
            {
                foreach(var item in value)
                {
                if(item.newcomment.Equals(true))
                {
                   use = true;
                    item.newcomment = false;
                }   
                }
                    appcontext.SaveChanges();
            }
            return use;
        }

    }
}
