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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly ContextSensive _context;
        public EfCategoryDal(ContextSensive context) : base(context)
        {
        }
        public void Delete(Category entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
