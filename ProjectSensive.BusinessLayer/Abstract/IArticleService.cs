using ProjectSensive.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSensive.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        List<Article> TArticleListWithCategory();
        List<Article> TArticleListWithCategoryAndAppUser();
        List<Article> TGetArticlesWithCategory();
        List<Article> TGetLast5ArticlesWithCategory();
        List<(string CategoryName, int Count)> TGetArticleCountByCategory();
        List<Article> TGetMostCommentedArticles(int count = 3);
        List<Article> TGetArticlesByAppUserId(int appUserId);

    }
}
