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
                          .Include(c => c.Article)
                          .Where(c => c.ArticleID == articleId)
                          .OrderByDescending(c => c.ArticleID)
                          .ToList();
        }
    }
}
