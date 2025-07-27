using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.DataAccessLayer.Abstract;
using ProjectSensive.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSensive.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(int id)
        {
            var category = _categoryDal.GetById(id);
            if (category != null)
            {
                _categoryDal.Delete(category);
            }
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void TInsert(Category entity)
        {
            if (!string.IsNullOrEmpty(entity.CategoryName) && entity.CategoryName.Length >= 5 && entity.CategoryName.Length <= 50)
            {
                _categoryDal.Insert(entity);
            }
            else
            {
                // loglama, exception vs. eklenebilir
            }
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
