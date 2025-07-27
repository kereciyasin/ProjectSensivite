using Microsoft.AspNetCore.Authentication;
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
    public class TagCloudManager : ITagCloudService
    {
        private readonly ITagCloudDal _tagCloudDal;

        public TagCloudManager(ITagCloudDal tagCloudDal)
        {
            _tagCloudDal = tagCloudDal;
        }

        public void TDelete(int id)
        {
            var entity = _tagCloudDal.GetById(id);
            if (entity != null)
            {
                _tagCloudDal.Delete(entity);
            }
        }

        public List<TagCloud> TGetAll()
        {
            return _tagCloudDal.GetAll();
        }

        public TagCloud TGetById(int id)
        {
            return _tagCloudDal.GetById(id);
        }

        public void TInsert(TagCloud entity)
        {
            _tagCloudDal.Insert(entity);
        }

        public void TUpdate(TagCloud entity)
        {
            _tagCloudDal.Update(entity);
        }
    }
}
