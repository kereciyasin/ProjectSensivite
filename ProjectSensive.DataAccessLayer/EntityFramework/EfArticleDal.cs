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
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        public EfArticleDal(ContextSensive context) : base(context)
        {
        }
        public List<Article> ArticleListWithCategory()
        {
            var context = new ContextSensive();
            var values = context.Articles.Include(x => x.Category).ToList();
            return values;
        }
        public List<Article> ArticleListWithCategoryAndAppUser()
        {
            var context = new ContextSensive();
            var values = context.Articles.Include(x => x.Category).Include(x => x.AppUser).ToList();
            return values;
        }

        public List<Article> GetArticlesWithCategory()
        {
            using var context = new ContextSensive();
            return context.Articles.Include(x => x.Category).ToList();
        }
    }
}
