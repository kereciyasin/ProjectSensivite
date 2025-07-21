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
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        private readonly ICategoryDal _categoryDal;

        public ArticleManager(IArticleDal articleDal, ICategoryDal categoryDal)
        {
            _articleDal = articleDal;
            _categoryDal = categoryDal;
        }

        public List<Article> TArticleListWithCategory()
        {
            return _articleDal.ArticleListWithCategory();
        }

        public List<Article> TArticleListWithCategoryAndAppUser()
        {
            return _articleDal.ArticleListWithCategoryAndAppUser();
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public List<Article> TGetArticlesWithCategory()
        {
            return _articleDal.GetArticlesWithCategory();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public void TUpdate(Article entity)
        {
            if (entity.Description != "" && entity.Title.Length >= 5 && entity.Title.Length <= 100)
            {
                _articleDal.Update(entity);
            }
            else
            {
                //Error message
            }
        }
    }
}
