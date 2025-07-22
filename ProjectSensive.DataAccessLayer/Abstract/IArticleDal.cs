using ProjectSensive.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSensive.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> ArticleListWithCategory();
        List<Article> ArticleListWithCategoryAndAppUser();
        List<Article> GetArticlesWithCategory();
        List<Article> GetLast5ArticlesWithCategory();
        List<(string CategoryName, int Count)> GetArticleCountByCategory();
        List<Article> GetMostCommentedArticles(int count);

    }
}
