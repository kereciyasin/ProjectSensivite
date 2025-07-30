using Microsoft.EntityFrameworkCore;
using ProjectSensive.DataAccessLayer.Abstract;
using ProjectSensive.DataAccessLayer.Context;
using ProjectSensive.DataAccessLayer.Repositories;
using ProjectSensive.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSensive.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public EfCommentDal(ContextSensive context) : base(context)
        {
        }

        public List<Comment> GetCommentsByArticle(int articleId)
        {
            using var context = new ContextSensive();
            return context.Comments
                .Include(c => c.AppUser)
                .Where(c => c.ArticleID == articleId && c.Status == true)
                .OrderByDescending(c => c.CommentDate)
                .ToList();
        }
        public List<Comment> GetCommentsForUserArticles(int userId)
        {
            using var context = new ContextSensive();

            return context.Comments
                .Include(c => c.Article)
                .Include(c => c.AppUser)
                .Where(c => c.Article.AppUserId == userId)
                .OrderByDescending(c => c.CommentDate)
                .ToList();
        }
    }
}
